using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RPG.control

{
    public class PatrolPath : MonoBehaviour
    {

        const float k�reninyar��ap� =0.3f;



        private void OnDrawGizmos()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                int j = GetNext�ndex(i);

                Gizmos.DrawSphere(GetPosition(i), k�reninyar��ap�);
                Gizmos.DrawLine(GetPosition(i), GetPosition(j));
            }
        }

        public UnityEngine.Vector3 GetPosition(int i)
        {
            return transform.GetChild(i).position;
        }

        public int GetNext�ndex(int i)
        {
            if (i + 1 == transform.childCount)
            {
                return 0;

            }
            return i + 1;
        }

       
       
       
          

        




    }

}