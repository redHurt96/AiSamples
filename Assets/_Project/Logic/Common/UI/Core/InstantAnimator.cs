using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Common.UI.Core
{
    public class InstantAnimator : MonoBehaviour, IWindowAnimator
    {
        public void Prepare()
        {
        }

        public UniTask Show()
        {
            gameObject.SetActive(true);
            return UniTask.CompletedTask;
        }

        public UniTask Hide()
        {
            gameObject.SetActive(false);
            return UniTask.CompletedTask;
        }
    }
}