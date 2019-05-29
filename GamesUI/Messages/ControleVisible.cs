using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesUI.Messages
{
    public class ControleVisible
    {
        public string Owner { get; private set; }

        public ControleVisible(string owner)
        {
            Owner = owner;
        }
    }
}
