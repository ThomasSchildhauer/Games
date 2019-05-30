using GamesBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesBase.Messages
{
    public class ControleHelper : IControleHelper
    {
        public IViewVisible ViewModel { get; set; }

        public ControleHelper()
        {

        }
        public void CheckVisibility(ControleVisible controleVisible)
        {
            if (string.Compare(controleVisible.Owner, nameof(ViewModel)) == 0)
            {
                ViewModel.Visible = true;
            }
            else
            {
                ViewModel.Visible = false;
            }
        }
    }
}
