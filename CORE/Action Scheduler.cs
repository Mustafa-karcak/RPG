using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.core
{
    public class ActionScheduler : MonoBehaviour
    {
        IAction actioncurrent;
        public void Startaction(IAction action)
        {
           if (actioncurrent == action) return;
            
            if (actioncurrent != null)
            {
                actioncurrent.Cancel();

            }
            actioncurrent = action;
        }

        public void StopCurrentAction()
        {
            Startaction(null);
        }
    }

}