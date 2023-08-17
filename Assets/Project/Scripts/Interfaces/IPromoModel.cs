using RedPanda.Project.Data;
using UnityEngine;

namespace RedPanda.Project.Interfaces
{
    public interface IPromoModel
    {
        string Title { get; }
        string GetIcon();
        string GetBackground();
        Color GetColorRare();
        PromoType Type { get; }
        PromoRarity Rarity { get; }
        int Cost { get; }
    }
}