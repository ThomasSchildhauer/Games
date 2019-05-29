using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GamesUI.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesUI.ViewModels
{
    public class LoginViewModel : ViewModelBase, ILoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        private bool _visible;

        public bool Visible
        {
            get => _visible;
            set
            {
                Set(nameof(Visible), ref _visible, value);
            }
        }

        public LoginViewModel()
        {
            MessengerInstance.Register<ControleVisible>(this, CheckVisibility);
        }

        private void CheckVisibility(ControleVisible controleVisible)
        {
            if (string.Compare(controleVisible.Owner, nameof(LoginViewModel))== 0)
            {
                Visible = true;
            }
            else
            {
                Visible = false;
            }
        }
    }
}
