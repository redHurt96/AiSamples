using _Project.Common.Characters.Model;
using _Project.Logic.Common.Characters;
using UniRx;
using UnityEngine;

namespace _Project.Logic.Common.UI
{
    internal class HealthViewModel
    {
        public readonly IReadOnlyReactiveProperty<float> HealthRelative;
        public readonly IReadOnlyReactiveProperty<Vector2> ScreenPosition;

        internal HealthViewModel(Health health, Camera camera, HealthViewAnchor anchor)
        {
            HealthRelative = health.Current
                .Select(x => x / health.Max)
                .ToReadOnlyReactiveProperty();

            ScreenPosition = anchor
                .ObserveEveryValueChanged(x => x.transform.position)
                .Select(x =>
                {
                    Vector3 screenPoint = camera.WorldToScreenPoint(x);
                    return new Vector2(
                        screenPoint.x - Screen.width / 2f, 
                        screenPoint.y - Screen.height / 2f);
                }).ToReadOnlyReactiveProperty();
        }
    }
}