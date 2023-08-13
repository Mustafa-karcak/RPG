using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinematics
{
    public class cinematics : MonoBehaviour
    {
        bool tekrargeçme = true;

        
        private void OnTriggerEnter(Collider other)
        {
         

            if (tekrargeçme && other.gameObject.tag == "Player")
          {
                tekrargeçme = false;
                GetComponent<PlayableDirector>().Play();
          }
                   
        }
    }

}