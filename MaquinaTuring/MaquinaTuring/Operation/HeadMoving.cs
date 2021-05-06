﻿using MaquinaTuring.Models;
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

        public int Move(string movement, string stringWrite, string stringReaded, Data data)
        {
            var debugEstadoDeCadena = Data.Instance.ListOfStringToString();
            try
            {
                switch (movement.ToLower())
                {
                    case "i":
                        if (data.HeadLocation != 0)
                        {
                            //Ver con eber si escribe antes de moverse o si se mueve el cabezal primero. 

                            data.ListOfString[data.HeadLocation - 1] = stringWrite;
                            data.HeadLocation = data.HeadLocation - 1;
                            debugEstadoDeCadena = Data.Instance.ListOfStringToString();
                            //Cambiar tambien el valor de la lista de strings... 
                        }
                        break;

                    case "d":
                        if (data.HeadLocation != data.ListOfString.Count)
                        {
                            data.ListOfString[data.HeadLocation - 1] = stringWrite;
                            data.HeadLocation = data.HeadLocation + 1;
                            debugEstadoDeCadena = Data.Instance.ListOfStringToString();
                        }
                        break;

                    case "p":

                        data.ListOfString[data.HeadLocation - 1] = stringWrite;
                        data.HeadLocation = data.HeadLocation;
                        debugEstadoDeCadena = Data.Instance.ListOfStringToString();
                        break;
                    case "O":
                        data.ListOfString[data.HeadLocation - 1] = stringWrite;
                        data.HeadLocation = data.HeadLocation; //Sola mente considerar que el cabezal no se mueva. 
                        debugEstadoDeCadena = Data.Instance.ListOfStringToString();
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
