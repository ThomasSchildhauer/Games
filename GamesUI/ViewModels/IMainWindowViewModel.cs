using System.Windows.Input;

namespace GamesUI.ViewModels
{
    public interface IMainWindowViewModel
    {
        ICommand Login { get; }
        IPluginViewModel PluginViewModel { get; set; }
        ICommand Refresh { get; }
    }
}