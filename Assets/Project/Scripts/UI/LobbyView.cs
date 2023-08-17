using RedPanda.Project.Services.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.Project.UI
{
    public sealed class LobbyView : View
    {
        [SerializeField] 
        private Button _promoButton;
        
        public override void Init()
        {
            _promoButton.onClick.AddListener(ShowPromoWindow);
        }

        private void OnDestroy()
        {
            _promoButton.onClick.RemoveAllListeners();
        }

        private void ShowPromoWindow()
        {
            Container.Locate<IUIService>().Close("LobbyView");
            Container.Locate<IUIService>().Show("PromoView");
        }
    }
}