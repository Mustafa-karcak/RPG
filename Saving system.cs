using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Saving
{
    public class Savingsystem : MonoBehaviour
    {
        public void Save(string savefile)
        {
            print("saving to" + savefile);
        }
       
        public void Load(string savefile)

        {
            print("loading" +savefile);
        }












    }
}