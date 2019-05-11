using System.Windows.Input;

namespace GamesUI.Templates
{
    public interface IPluginsTemplate
    {
        ICommand ButtonCommand { get; set; }
        string ButtonText { get; set; }
    }
}