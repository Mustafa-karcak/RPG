using RPG.Combat;
using RPG.core;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movmentmover
{

    public class Mover : MonoBehaviour, IAction

    {
        [SerializeField] Transform enemy;
        NavMeshAgent agent;
        Health health;

        [SerializeField] float maxspeed = 5f;


        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            health = GetComponent<Health>();
        }

        void Update()
        {
            agent.enabled = !health.dead();
            updatespeed();

        }
        public void Movetoaction(Vector3 destination, float speedfraction)
        {

            GetComponent<ActionScheduler>().Startaction(this);
            MoveTo(destination, speedfraction);
        }
        public void MoveTo(Vector3 destination, float speedfraction)
        {
            agent.destination = destination;
            agent.isStopped = false;
            agent.speed = maxspeed * Mathf.Clamp01(speedfraction);
        }

        public void Cancel()
        {
            agent.isStopped = true;
        }

        void updatespeed()
        {
            Vector3 hýz = agent.velocity;
            Vector3 localvelocity = transform.InverseTransformDirection(hýz);
            float speed = localvelocity.z * Time.deltaTime * 100;
            GetComponent<Animator>().SetFloat("forwardspeed", speed);


        }


    }

}
