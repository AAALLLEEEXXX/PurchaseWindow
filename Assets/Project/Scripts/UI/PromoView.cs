using RedPanda.Project.Data;
using RedPanda.Project.Interfaces;
using RedPanda.Project.SerializableDictionary;
using RedPanda.Project.Services.Interfaces;
using UnityEngine;

namespace RedPanda.Project.UI
{
    public sealed class PromoView : View
    {
        [SerializeField] 
        private CurrencyView _currencyView;

        [SerializeField]
        private SerializableDictionary<PromoType, CategorySlotView> _categorySlots;

        private IUserService _userService;

        public override void Init()
        {
            _userService = Container.Locate<IUserService>();

            InitCategories();
            RefreshCurrencyView(_userService.Currency);
        }

        private void OnDestroy()
        {
            foreach (var categorySlot in _categorySlots.Values)
            {
                categorySlot.OnBuyPromo -= BuyPromo;
                categorySlot.Dispose();
            }
        }

        private void InitCategories()
        {
            var promos = Container.Locate<IPromoService>().GetPromos();

            foreach (var promo in promos)
            {
                if (_categorySlots.TryGetValue(promo.Type, out var categorySlotView))
                    categorySlotView.AddPromoModel(promo);
            }

            foreach (var categorySlot in _categorySlots)
            {
                categorySlot.Value.Init();
                categorySlot.Value.OnBuyPromo += BuyPromo;
            }
        }

        private void BuyPromo(IPromoModel promoModel)
        {
            var cost = promoModel.Cost;

            if (_userService.HasCurrency(cost))
            {
                _userService.ReduceCurrency(cost);
                RefreshCurrencyView(_userService.Currency);
                Debug.Log($"Purchase {promoModel.Title} completed!");
            }
            else
            {
                Debug.LogError("Not enough currency to buy!");
            }
        }

        private void RefreshCurrencyView(int currentCurrency)
        {
            _currencyView.RefreshData(currentCurrency);
        }
    }
}
