using MaquinaTuring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaTuring.Operation
{
    public class OperationText
    {
           public Data ObtenerData(Data data)
           {
                var Cadena = "_hola";
                for (int i = 0; i < Cadena.Length; i++)
                {
                    data.ListOfString.Add(Cadena[i].ToString());
                }
                return data;
           }
    }
}
