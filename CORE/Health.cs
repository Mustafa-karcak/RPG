using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float health = 100f;
        bool �sdead = false;
        
        public bool dead()

        {
            return �sdead;
        }

        public void attackhealth(float damage)
        {
            health = Mathf.Max(health - damage,0);
            print(gameObject.name + health );
            if (health == 0)
            {
                DEATH();
                
            }
        }

        private void DEATH()
        {
            if (�sdead) return;
         
            �sdead = true;
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<ActionScheduler>().StopCurrentAction();
        }

    }
}