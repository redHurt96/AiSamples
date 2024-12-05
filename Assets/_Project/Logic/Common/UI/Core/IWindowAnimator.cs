using Cysharp.Threading.Tasks;

namespace _Project.Common.UI.Core
{
    public interface IWindowAnimator
    {
        void Prepare();
        UniTask Show();
        UniTask Hide();
    }
}