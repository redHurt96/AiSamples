using _Project.Common.UI.Core;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using static System.TimeSpan;
using static Cysharp.Threading.Tasks.UniTask;
using static UnityEngine.Screen;

namespace _Project.Common.UI.Implementation.Animators
{
    public class SlideUpAnimator : MonoBehaviour, IWindowAnimator
    {
        [SerializeField] private RectTransform _window;
        [SerializeField] private float _duration = .5f;

        public void Prepare() => 
            _window.anchoredPosition += Vector2.down * height;

        public async UniTask Show() => await Tween(0f);
        public async UniTask Hide() => await Tween(-height);

        private async UniTask Tween(float target)
        {
            Tween tween = _window.DOLocalMoveY(target, _duration);
            await Delay(FromSeconds(tween.Duration()));
        }
    }
}
