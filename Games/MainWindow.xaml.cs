using System.Windows;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Games
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel();      
            InitializeComponent();            
        }
    }
}
