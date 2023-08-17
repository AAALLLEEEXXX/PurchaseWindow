using RedPanda.Project.Interfaces;
using UnityEngine;

namespace RedPanda.Project.Data
{
    public sealed class PromoModel<TModelData> : IPromoModel where TModelData : PromoData
    {
        private TModelData _data;

        string IPromoModel.Title => _data.Title;
        string IPromoModel.GetIcon() => _data.Icon();
        string IPromoModel.GetBackground() => _data.Background();
        Color IPromoModel.GetColorRare() => _data.ColorRare();
        PromoType IPromoModel.Type => _data.Type;
        PromoRarity IPromoModel.Rarity => _data.Rarity;
        int IPromoModel.Cost => _data.Cost;
        
        public PromoModel(TModelData data)
        {
            _data = data;
        }
    }
}