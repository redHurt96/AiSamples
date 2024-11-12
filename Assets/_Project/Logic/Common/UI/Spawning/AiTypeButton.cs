using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Common.UI.Spawning
{
    public class AiTypeButton : MonoBehaviour
    {
        [SerializeField] private Image _outline;
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private Button _button;

        public void Construct(AiType aiType) => 
            _title.text = aiType.ToString();

        public IObservable<Unit> OnClickAsObservable() => 
            _button.OnClickAsObservable();

        public void Select() => 
            _outline.enabled = true;

        public void Deselect() => 
            _outline.enabled = false;
    }
}