using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaTuring.Models
{
    public class Transition
    {
        public string InitialState { get; set; }

        public string CharacterRead { get; set; }

        public string FinalState { get; set; }

        public string CharacterWrite { get; set; }

        public char HeadMovement { get; set; }

    }
}
