using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaTuring.Models
{
    public class State
    {
        public string IdState { get; set; }

        public List<Transition> ListOfTransition;

        public State()
        {
            ListOfTransition = new List<Transition>();
        }
    }
}
