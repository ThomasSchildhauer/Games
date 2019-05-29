using System.Windows.Input;

namespace GamesUI.ViewModels
{
    public interface IMainWindowViewModel
    {
        ICommand LoginCommand { get; }
        ILoginViewModel LoginViewModel { get; }
        ICommand PluginsCommand { get; }
        IPluginViewModel PluginViewModel { get; set; }
        ICommand RefreshCommand { get; }
    }
}