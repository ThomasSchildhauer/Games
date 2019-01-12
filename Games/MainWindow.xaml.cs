using System.Windows;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Games
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //ToDo have to update this to .Net 4.6
        private static readonly log4net.ILog log = Logger.GetNewLogger();

        public MainWindow()
        {
            log.Debug("Start Games Programm");
            InitializeComponent();
        }
    }
}
