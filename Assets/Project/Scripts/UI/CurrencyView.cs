using TMPro;
using UnityEngine;

namespace RedPanda.Project.UI
{
    public class CurrencyView : MonoBehaviour
    {
        [SerializeField] 
        private TMP_Text _countLabel;

        public void RefreshData(int currency)
        {
            _countLabel.text = currency.ToString();
        }
    }
}
