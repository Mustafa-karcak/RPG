using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movmentmover;
using RPG.core;
using RPG.control;
using System;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour,IAction
    {
     
        [SerializeField] Transform Righthandtransform = null;
        [SerializeField] Transform Lefthandtransform = null;
       [SerializeField] Weapon defaultweapon = null;


        float sonsaldýrýdanbuyanageçensüre = Mathf.Infinity;
        Health target;
        Weapon CurrentWeapon = null;    
       
        private void Start()
        {
            SpawnWeapon(defaultweapon);
           
         
        }

       

        private void Update()
        {
            sonsaldýrýdanbuyanageçensüre += Time.deltaTime;
          
                if (target == null) return;
            if (target.dead()) return;  
          
            if (!RANGEMETHOD())
            {
                GetComponent<Mover>().MoveTo(target.transform.position,1f);

            }
            else
            {
                GetComponent<Mover>().Cancel();
                attackbehaviour();
                
            }
        }
        public void SpawnWeapon(Weapon weapon)
        {
                CurrentWeapon = weapon;
                Animator animator = GetComponent<Animator>();
                CurrentWeapon.Spawn(Righthandtransform,Lefthandtransform, animator);
            
        }


        private void attackbehaviour()
        {
            transform.LookAt(target.transform);
            if (sonsaldýrýdanbuyanageçensüre > CurrentWeapon.GetChange())
            {

                GetComponent<Animator>().SetTrigger("attack");
                sonsaldýrýdanbuyanageçensüre = 0;
                GetComponent<Animator>().SetTrigger("stopAttack");
            }
            
                    
        }

      


        public void Hit()
       {
            if (target == null) { return; }
            if(CurrentWeapon.Hasprojecttile())
            {
                CurrentWeapon.LaunchProjecttile(Righthandtransform, Lefthandtransform, target);
            }
            else
            {
                target.attackhealth(CurrentWeapon.Getdamage());
            }
            
          
        }
        void Shoot()
        {
            Hit();
        }
        
        
        bool RANGEMETHOD()
        {
            return Vector3.Distance(transform.position, target.transform.position) < CurrentWeapon.GetChange();
        }

        public bool Canattack(GameObject combattarget)
        {
            if (combattarget == null) { return false; }
            Health health = combattarget.GetComponent<Health>();
            return health != null && !health.dead();
        }
       
        
        public void Attack(GameObject Combattarget)
        {
            target = Combattarget.GetComponent<Health>();
            GetComponent<ActionScheduler>().Startaction(this);
        }
        public void Cancel()
        {
            stopattack();
            GetComponent<Mover>().Cancel();
            target = null;
        }
        private void stopattack()
        {
            GetComponent<Animator>().ResetTrigger("attack");
            GetComponent<Animator>().SetTrigger("stopAttack");
        }
    }


}