using RPG.core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

using RPG.control;


namespace RPG.Cinematics
{

    public class cinematiccontroremoverl : MonoBehaviour
    {
        GameObject player;


        void Start()
        {
            GetComponent<PlayableDirector>().played += Disablecontrol;
            GetComponent<PlayableDirector>().stopped += EnableControl;
            player = GameObject.FindWithTag("Player");
        }

        void Disablecontrol(PlayableDirector pd)
        {
            player.GetComponent<ActionScheduler>().StopCurrentAction();
            player.GetComponent<Movement>().enabled = false;
            print("disablecontrol aktif");
        }
        void EnableControl(PlayableDirector pd)

        {
            player.GetComponent<Movement>().enabled = true;
            print("EnableControl aktif");
        }



    }
}