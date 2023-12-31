using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.core
{
    public class PersistenObjectsSpawn : MonoBehaviour
    {
        [SerializeField] GameObject kalıcınesne;

        static bool parlama = false;
        private void Awake()
        {
            if (parlama) return;
            Spawnpersistenobjects();
            parlama = true;
        }

        private void Spawnpersistenobjects()
        {
            GameObject persisten = Instantiate(kalıcınesne);
          
            DontDestroyOnLoad(persisten);
        }
    }
}