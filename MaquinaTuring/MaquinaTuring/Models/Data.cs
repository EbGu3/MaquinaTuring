﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaTuring.Models
{
    public class Data
    {

        private static Data _instance;

        public static Data Instance
        {
            get
            {
                if (_instance == null) _instance = new Data();
                return _instance;
            }
        }

        
        public int HeadLocation {get; set;}

        public List<State> ListOfStates = new List<State>();

        public List<string> ListOfString = new List<string>();

        public string Path;

        public int NumberState;

        public string FirstState;

        public ActualState ActualState = new ActualState();

        public static void ResetData()
        {
            _instance = new Data();
        }
    }
}
