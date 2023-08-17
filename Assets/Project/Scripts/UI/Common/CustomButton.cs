using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RedPanda.Project.UI.Common
{
    public class CustomButton : Button
    {
        private const float MinScale = 0.8f;
        
        public static string Duration => nameof(_duration);

        [SerializeField]
        private float _duration = 0.6f;

        private float HalfDuration => _duration / 2;
        
        private RectTransform _rectTransform;
        private Sequence _sequence;
        
        protected override void Awake()
        {
            base.Awake();
        
            _rectTransform = GetComponent<RectTransform>();
        }
        
        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
        
            ActivateAnimation();
        }
        
        private void ActivateAnimation()
        {
            _rectTransform.localScale = Vector3.one;
        
            _sequence?.Kill();
        
            _sequence = DOTween.Sequence();
            _sequence.Append(_rectTransform.DOScale(Vector3.one * MinScale, HalfDuration));
            _sequence.Append(_rectTransform.DOScale(Vector3.one, HalfDuration));
        
            _sequence.Restart();
        }
    }
}
