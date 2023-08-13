using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Saving
{
    public class SavingWrapper : MonoBehaviour
    {
        const string defaultsavefile = "save";

        Savingsystem savingsystem;

        private void Start()
        {
            savingsystem = GetComponent<Savingsystem>();
        }


        void Update()
        {
            if(Input.GetKeyDown(KeyCode.S))
            {
                savingsystem.Save(defaultsavefile);
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                savingsystem.Load(defaultsavefile);
            }
        }
    }
}

