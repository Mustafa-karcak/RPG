using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinematics
{
    public class cinematics : MonoBehaviour
    {
        bool tekrarge�me = true;

        
        private void OnTriggerEnter(Collider other)
        {
         

            if (tekrarge�me && other.gameObject.tag == "Player")
          {
                tekrarge�me = false;
                GetComponent<PlayableDirector>().Play();
          }
                   
        }
    }

}