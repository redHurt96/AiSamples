using Cysharp.Threading.Tasks;

namespace _Project.Common.UI.Core
{
    public interface IWindow<in T> : IWindow
    {
        void Setup(T viewModel);
    }
    public interface IWindow
    {
        UniTask Show();
        UniTask Hide();
    }
}