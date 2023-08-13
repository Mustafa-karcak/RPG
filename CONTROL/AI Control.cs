using RPG.Combat;
using RPG.core;
using RPG.Movmentmover;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;


namespace RPG.control
{
    public class AIControl : MonoBehaviour
    {
        [SerializeField] float chasedistance = 5f;
        [SerializeField] float suspicitontime = 3f;
        [SerializeField] PatrolPath patrolpath;
        [SerializeField] float waypointtollarence = 2f;
       
        [SerializeField] float döngüdebeklemesüresi = 1f;
        [SerializeField] float döngüdebeklemesüresi2 = 4f;

        [Range(0,1)][SerializeField] float patrolpathspeed = 0.2f;
    
        Fighter fighter;
        GameObject player;
        Health health;
        Mover mover;

        
        Vector3 guardlocation;
        float timesincelastplayer = Mathf.Infinity;
      
        int currentwaypointindex = 0;
        private void Start()
        {
            fighter = GetComponent<Fighter>();
            player = GameObject.FindWithTag("Player");
            health = GetComponent<Health>();
            mover = GetComponent<Mover>();

          
            guardlocation = transform.position;
        }


        private void Update()
        {
            if (health.dead()) return;
       
            if (InAttackRangeofThePlayer() && fighter.Canattack(player))
            { 
                timesincelastplayer = 0;
                Attacbehaviour();
               
            }
            else if(timesincelastplayer < suspicitontime)
            {
                suspicinBehaviour();
            }

            else
            {
                PatrolBehaviour();

            }
            timesincelastplayer += Time.deltaTime;
            döngüdebeklemesüresi += Time.deltaTime;
        }

        private void PatrolBehaviour()
        {
            Vector3 nextposizyon = guardlocation;

            if (patrolpath != null)

            {
                if (atwaypoint())
                {
                    cyclewaypoint();
                    döngüdebeklemesüresi = 0;
                }
                nextposizyon = Getcurrentwaypoint();
            }

            
            if (döngüdebeklemesüresi > döngüdebeklemesüresi2)
            {
                mover.Movetoaction(nextposizyon,patrolpathspeed);
            }
            

        }
        private bool atwaypoint()
        {
            float distance = Vector3.Distance(transform.position, Getcurrentwaypoint());
          return   distance < waypointtollarence ;
        }
        private void cyclewaypoint()
        {
            currentwaypointindex = patrolpath.GetNextÝndex(currentwaypointindex);
           
            
                
            
        }

        private Vector3 Getcurrentwaypoint()
        {
            return patrolpath.GetPosition(currentwaypointindex);
        }

       
      
      
        
        private void suspicinBehaviour()
        {
            GetComponent<ActionScheduler>().StopCurrentAction();
        }

        private void Attacbehaviour()
        {
            fighter.Attack(player);
        }

        private bool InAttackRangeofThePlayer()
        {
            
           return Vector3.Distance(player.transform.position,transform.position) < chasedistance;
        
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(transform.position, chasedistance);
        }
        
        

        
    
    }

}