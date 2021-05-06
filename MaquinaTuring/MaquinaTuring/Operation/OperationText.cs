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

        public void MovingOneTransition(string ActualState, string _ActualCharacter)
        {
            var searchState = Data.Instance.ListOfStates.Find(x => x.IdState == ActualState);
            if (searchState != null)
            {
                //Obtener el caracter 
                //Menos 1 porque la cadena empieza en 0, se ubica en 1 por la columna de descripcion
                var ActualCharacter = _ActualCharacter;

                //Buscar la transicion que consuma dicho caracter
                var ExistTransition = searchState.ListOfTransition.Find(x => x.CharacterRead == ActualCharacter);
                if (ExistTransition != null)
                {
                    ToAssignActualState(ExistTransition);
                    HeadMoving headMoving = new HeadMoving();
                    //bool encontrarh = (ExistTransition.FinalState.ToLower() == "h");
                    bool encontrarh = (ExistTransition.HeadMovement.ToString().ToLower() == "p");
                    //bool encontrar_ = (Data.Instance.ListOfString[Data.Instance.HeadLocation - 1] == "_");
                    if (encontrarh /*&& encontrar_*/)
                    {
                        headMoving.Move(ExistTransition.HeadMovement.ToString(), ExistTransition.CharacterWrite, ExistTransition.CharacterRead, Data.Instance);
                        Data.Instance.isInHState = true;
                    }
                    else
                    {
                        headMoving.Move(ExistTransition.HeadMovement.ToString(), ExistTransition.CharacterWrite, ExistTransition.CharacterRead, Data.Instance);
                    }

                }
            }
        }



        //Estado actual que se encuentra la maquina
        public void ToAssignActualState(Transition transition)
           {
                Data.Instance.ActualState.ActualTransition.CharacterRead = transition.CharacterRead;
                Data.Instance.ActualState.ActualTransition.CharacterWrite = transition.CharacterWrite;
                Data.Instance.ActualState.ActualTransition.FinalState = transition.FinalState;
                Data.Instance.ActualState.ActualTransition.InitialState = transition.InitialState;
                Data.Instance.ActualState.ActualTransition.HeadMovement = transition.HeadMovement;
           }

           //Ocurre el cambio de transiciones
           public void MovingTransition(string ActualState)
           {
                var searchState = Data.Instance.ListOfStates.Find(x => x.IdState == ActualState);
                if(searchState != null)
                {
                    //Obtener el caracter 
                    //Menos 1 porque la cadena empieza en 0, se ubica en 1 por la columna de descripcion
                    var ActualCharacter = Data.Instance.ListOfString[Data.Instance.HeadLocation - 1];
                    
                    //Buscar la transicion que consuma dicho caracter
                    var ExistTransition = searchState.ListOfTransition.Find(x => x.CharacterRead == ActualCharacter);
                    if(ExistTransition != null)
                    {
                        ToAssignActualState(ExistTransition);
                        HeadMoving headMoving = new HeadMoving();
                    //bool encontrarh = (ExistTransition.FinalState.ToLower() == "h");
                    bool encontrarh = (ExistTransition.HeadMovement.ToString().ToLower() == "p");
                    bool encontrar_ = (Data.Instance.ListOfString[Data.Instance.HeadLocation - 1] == "_");
                    if (encontrarh && encontrar_)
                        {
                            headMoving.Move(ExistTransition.HeadMovement.ToString(), ExistTransition.CharacterWrite, ExistTransition.CharacterRead, Data.Instance);
                            
                        }
                        else
                        {
                            headMoving.Move(ExistTransition.HeadMovement.ToString(), ExistTransition.CharacterWrite, ExistTransition.CharacterRead, Data.Instance);
                            MovingTransition(ExistTransition.FinalState);
                        }
                        
                    }  
                }
           }


    }
}
