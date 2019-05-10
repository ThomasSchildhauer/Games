using GamesUI.ViewModels;
using System.Windows;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace GamesUI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            DataContext = new MainWindowViewModel();      
            InitializeComponent();            
        }
    }
}
