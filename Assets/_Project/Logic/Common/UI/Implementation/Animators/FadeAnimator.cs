using _Project.Common.UI.Core;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using static System.TimeSpan;
using static Cysharp.Threading.Tasks.UniTask;

namespace _Project.Common.UI.Implementation.Animators
{
    public class FadeAnimator : MonoBehaviour, IWindowAnimator
    {
        [SerializeField] private CanvasGroup _window;
        [SerializeField] private float _duration = .5f;

        public void Prepare() => 
            _window.alpha = 0f;

        public async UniTask Show() => await Tween(1f);

        public async UniTask Hide() => await Tween(0f);

        private async UniTask Tween(float target)
        {
            Tween tween = _window.DOFade(target, _duration);
            await Delay(FromSeconds(tween.Duration()));
        }
    }
}