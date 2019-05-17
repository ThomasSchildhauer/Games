using System.Windows.Input;

namespace GamesUI.Templates
{
    public interface IPluginsTemplate
    {
        ICommand ButtonCommand { get; }
        string ButtonText { get; }
    }
}