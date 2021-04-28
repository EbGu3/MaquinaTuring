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

           //Estado actual que se encuentra la maquina
           public void ToAssignActualState(Transition transition)
           {
                Data.Instance.ActualState.ActualTransition.CharacterRead = transition.CharacterRead;
                Data.Instance.ActualState.ActualTransition.CharacterWrite = transition.CharacterWrite;
                Data.Instance.ActualState.ActualTransition.FinalState = transition.FinalState;
                Data.Instance.ActualState.ActualTransition.InitialState = transition.InitialState;
                Data.Instance.ActualState.ActualTransition.HeadMovement = transition.HeadMovement;
           }
    }
}
