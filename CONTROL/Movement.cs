using RPG.Combat;
using RPG.core;
using RPG.Movmentmover;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Apple;

namespace RPG.control
{
    public class Movement : MonoBehaviour   //düþmana saldýrmak için
    {
        Health health;
      
        private void Start()
        {
            health = GetComponent<Health>();
       
        }


        private void Update()
        {
            if (health.dead()) return;
           
            
            if (incractivewithCombat()) return;

            
           if (incractivewithmovement()) return;

           
        }
        private bool incractivewithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target == null) continue;

                GameObject targetGameObject = target.gameObject;
                if (!GetComponent<Fighter>().Canattack(target.gameObject))
                { 
                continue;
                }
 
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Fighter>().Attack(target.gameObject);

                }
                return true;
           }
            return false;
        }

        private Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        bool incractivewithmovement()
            
            
    
        {
            RaycastHit hit;
            bool hashit = Physics.Raycast(GetMouseRay(), out hit);
            if (hashit)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().Movetoaction(hit.point,1f);

                }
                return true;
            }

            return false;

        }

    }
}