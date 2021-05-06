using MaquinaTuring.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaquinaTuring.Operation
{
    public class FileManagement
    {
        public void LecturaArchivo(string path)
        { 
             using(StreamReader streamReader = new StreamReader(path))
             {
                var LineRead = "";
                var FileLocalitation = 0;
                while(((LineRead = streamReader.ReadLine()) != null))
                {
                    if(FileLocalitation == 0)
                    {
                        Data.Instance.NumberState = Convert.ToInt32(LineRead);
                    }
                    else if(FileLocalitation == 1)
                    {
                        Data.Instance.FirstState = LineRead;
                    }
                    else if(Regex.IsMatch(LineRead, @"^[_]?[a-zA-Z0-9\#$%&()[\]{}\/*\-+=?¿!¡]*[_]?$"))
                    {
                        //Asignar el alfabeto y ya no la cadena
                        for (int i = 0; i < LineRead.Length; i++)
                        {
                          
                            Data.Instance.ListOfAlphabet.Add(LineRead[i].ToString());
                        }
                        
                    }
                    else
                    {
                        var SplitLine = LineRead.Split(',');
                        var newTransition = new Transition() 
                        {
                            InitialState = SplitLine[0],
                            CharacterRead = SplitLine[1],
                            FinalState = SplitLine[2],
                            CharacterWrite = SplitLine[3],
                            HeadMovement = Convert.ToChar(SplitLine[4])
                        };
                       
                        if(Data.Instance.ListOfStates.Exists(x => x.IdState == newTransition.InitialState))
                        {
                            foreach (var item in Data.Instance.ListOfStates)
                            {
                                if(item.IdState == newTransition.InitialState)
                                {
                                    item.ListOfTransition.Add(newTransition);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            
                            var listTransition = new List<Transition>();
                            listTransition.Add(newTransition);
                            var newState = new State() { IdState = newTransition.InitialState, ListOfTransition = listTransition };
                            Data.Instance.ListOfStates.Add(newState);
                            
                        }
                    }
                    FileLocalitation++;
                }

                //Buscar cual es el primer nodo y asignar la transicion inicial
                var searchState = Data.Instance.ListOfStates.Find(x => x.IdState == Data.Instance.FirstState);
                if(searchState != null)
                {
                    var operation = new OperationText();
                    foreach (var item in searchState.ListOfTransition)
                    {
                        operation.ToAssignActualState(item);
                    }
                }
             }                
        }
    }
}
