using System;
using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using RedPanda.Project.Interfaces;
using UnityEngine;

namespace RedPanda.Project.UI
{
    public class CategorySlotView : MonoBehaviour, IEnhancedScrollerDelegate, IDisposable
    {
        [SerializeField] 
        private EnhancedScroller _scroller;
        
        [SerializeField] 
        private PromoSlotView _promoSlotView;
        
        private readonly List<IPromoModel> _promoModels = new();
        
        public event Action<IPromoModel> OnBuyPromo;
        
        public void AddPromoModel(IPromoModel promoModel)
        {
            _promoModels.Add(promoModel);
        }

        public void Init()
        {
            _promoModels.Sort((a, b) => -a.Rarity.CompareTo(b.Rarity));
            
            _scroller.Delegate = this;
            _scroller.ReloadData();
        }

        public void Dispose()
        {
            _promoModels.Clear();
        }

        public int GetNumberOfCells(EnhancedScroller scroller) => _promoModels.Count;

        public float GetCellViewSize(EnhancedScroller scroller, int dataIndex) => _promoSlotView.CellSize;

        public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
        {
            var cellView = scroller.GetCellView(_promoSlotView) as PromoSlotView;

            if (cellView == null)
            {
                Debug.LogError($"CellView is null! Check {nameof(_promoSlotView)} reference.");
                return cellView;
            }
            
            cellView.Dispose();
            cellView.SetData(_promoModels[dataIndex], BuyPromo);
            
            return cellView;
        }

        private void BuyPromo(IPromoModel promoModel)
        {
            OnBuyPromo?.Invoke(promoModel);
        }
    }
}
