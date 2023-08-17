using System.Collections.Generic;
using UnityEngine;

namespace RedPanda.Project.Data
{
    public class PromoData
    {
        private Dictionary<PromoRarity, Color> _colors = new()
        {
            {PromoRarity.Common, new Color(0.04313726f, 0.509804f, 0.7960785f)},
            {PromoRarity.Epic, new Color(0.9921569f, 0.6666667f, 0.2588235f)},
            {PromoRarity.Rare, new Color(0.7960785f, 0.3176471f, 0.9254903f)}
        };

        public PromoType Type { get; }

        public string Title { get; }

        public PromoRarity Rarity { get; }

        public int Cost { get; }
        
        public string Icon()
        {
            return $"sprite_{Type.ToString().ToLower()}_{Rarity.ToString().ToLower()}";
        }
        
        public string Background()
        {
            return $"background_{Rarity.ToString().ToLower()}";
        }
        
        public Color ColorRare()
        {
            return _colors[Rarity];
        }

        public PromoData(string title, PromoType type, PromoRarity rarity, int cost)
        {
            Title = title;
            Type = type;
            Rarity = rarity;
            Cost = cost;
        }
    }

    public enum PromoRarity
    {
        Common,
        Rare,
        Epic
    }

    public enum PromoType
    {
        Chest,
        Special,
        InApp
    }
}