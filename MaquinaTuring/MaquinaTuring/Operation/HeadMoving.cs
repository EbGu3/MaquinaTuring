using MaquinaTuring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaquinaTuring.Operation
{
    public class HeadMoving
    {
        public int Move(string movement, string stringWrite, Data data)
        {
            try
            {
                switch (movement.ToLower())
                {
                    case "i":
                        if (data.HeadLocation != 0)
                        {
                            data.HeadLocation = data.HeadLocation - 1;
                        }
                        break;

                    case "d":
                        if (data.HeadLocation != data.ListOfString.Count)
                        {
                            data.HeadLocation = data.HeadLocation + 1;
                        }
                        break;

                    case "p":
                        data.HeadLocation = data.HeadLocation;
                        break;
                }

                return data.HeadLocation;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

    }
}
