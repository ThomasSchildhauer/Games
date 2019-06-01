using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GamesBase.Messages;
using GamesBase.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesUI.ViewModels
{
    public class LoginViewModel : ViewModelVisibilityBase, ILoginViewModel
    {
        private UIViewModelToken _token;
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginViewModel(UIViewModelToken token) : base(nameof(LoginViewModel))
        {
            _token = token;
            MessengerInstance.Register<ControleVisible>(this, _token, CheckVisibility);
        }
    }
}
