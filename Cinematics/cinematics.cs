using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinematics
{
    public class cinematics : MonoBehaviour
    {
        bool tekrargeÁme = true;

        
        private void OnTriggerEnter(Collider other)
        {
         

            if (tekrargeÁme && other.gameObject.tag == "Player")
          {
                tekrargeÁme = false;
                GetComponent<PlayableDirector>().Play();
          }
                   
        }
    }

}