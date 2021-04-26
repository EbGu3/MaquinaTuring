﻿using MaquinaTuring.Models;
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
                var LineRead = streamReader.ReadLine();
                var FileLocalitation = 0;
                while(!streamReader.EndOfStream)
                {
                    if(FileLocalitation == 0)
                    {
                        Data.Instance.NumberState = Convert.ToInt32(LineRead);
                    }
                    else if(FileLocalitation == 1)
                    {
                        Data.Instance.FirstState = LineRead;
                    }
                    else if(FileLocalitation == 2)
                    {
                        for (int i = 0; i < LineRead.Length; i++)
                        {
                            Data.Instance.ListOfString.Add(LineRead[i].ToString());
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
                    LineRead = streamReader.ReadLine();
                    FileLocalitation++;
                }
             }                
        }
    }
}