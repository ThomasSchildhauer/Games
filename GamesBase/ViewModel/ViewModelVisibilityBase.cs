using GalaSoft.MvvmLight;
using GamesBase.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesBase.ViewModel
{
    public abstract class ViewModelVisibilityBase : ViewModelBase
    {
        private bool _visible;

        public virtual bool Visible
        {
            get => _visible;
            set
            {
                Set(nameof(Visible), ref _visible, value);
            }
        }

        public ViewModelVisibilityBase()
        {
            MessengerInstance.Register<ControleVisible>(this, CheckVisibility);
        }

        private void CheckVisibility(ControleVisible controleVisible)
        {
            if (string.Compare(controleVisible.Owner, nameof(ViewModel)) == 0)
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
