using _Project.Common.Characters.Model;
using UniRx;
using UnityEngine;

namespace _Project.Common.Vfx.Freeze
{
    public class FreezeVfx : MonoBehaviour
    {
        [SerializeField] private GameObject _vfx;
        
        private FreezeEffect _freezeEffect;

        public void Construct(FreezeEffect freezeEffect) => 
            _freezeEffect = freezeEffect;

        private void Start() =>
            _freezeEffect.InFreeze
                .Subscribe(ToggleEffect)
                .AddTo(this);

        private void ToggleEffect(bool enabled) => 
            _vfx.SetActive(enabled);
    }
}
