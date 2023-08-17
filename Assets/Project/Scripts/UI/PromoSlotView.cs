using System;
using EnhancedUI.EnhancedScroller;
using RedPanda.Project.Interfaces;
using RedPanda.Project.UI.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.Project.UI
{
    public class PromoSlotView : EnhancedScrollerCellView, IDisposable
    {
        [SerializeField]
        private RectTransform _rectTransform;
        
        [SerializeField] 
        private CustomButton _button;
        
        [SerializeField] 
        private Image _imageProduct;
        
        [SerializeField] 
        private Image _background;
        
        [SerializeField] 
        private TMP_Text _titleLabel;
        
        [SerializeField] 
        private TMP_Text _priceLabel;

        public event Action<IPromoModel> OnBuyPromo;
        private IPromoModel _promoModel;
            
        public float CellSize => _rectTransform.sizeDelta.x;

        public void SetData(IPromoModel promoModel, Action<IPromoModel> buyAction)
        {
            _promoModel = promoModel;
            
            _background.sprite = Resources.Load<Sprite>($"Sprites/{promoModel.GetBackground()}");
            _imageProduct.sprite = Resources.Load<Sprite>($"Sprites/{promoModel.GetIcon()}");
            _titleLabel.text = promoModel.Title;
            _titleLabel.color = promoModel.GetColorRare();
            _priceLabel.text = $"x{promoModel.Cost}";
            
            _button.onClick.AddListener(() => buyAction.Invoke(_promoModel));
        }

        public void Dispose()
        {
            _button.onClick.RemoveAllListeners();
        }

        private void BuyPromo()
        {
            OnBuyPromo?.Invoke(_promoModel);
        }
    }
}
