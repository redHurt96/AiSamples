using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Common.UI.HealthBar
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Image _fill;
        [SerializeField] private RectTransform _rectTransform;
        
        private HealthViewModel _viewModel;

        internal void Construct(HealthViewModel viewModel) => 
            _viewModel = viewModel;

        private void Start()
        {
            _viewModel.HealthRelative
                .Subscribe(Draw)
                .AddTo(this);

            _viewModel.ScreenPosition
                .Subscribe(Move)
                .AddTo(this);
        }

        private void Draw(float value) => 
            _fill.fillAmount = value;

        private void Move(Vector2 toPosition) => 
            _rectTransform.anchoredPosition = toPosition;
    }
}
