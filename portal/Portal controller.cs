using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

namespace RPG.portal
{
    public class Portalcontroller : MonoBehaviour
    {
        enum DestinationIdentifier
        {
            A,B,C,D,E

        }

        [SerializeField]  int sonrakilevel = 1;
        [SerializeField] Transform spawnpoint;
        [SerializeField] DestinationIdentifier destination;
        [SerializeField] float canvasartýrzamaný = 2f;
        [SerializeField] float canvasazaltzamaný = 1f;
        [SerializeField] float sahnebeklemezamaný = 0.5f;
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                StartCoroutine(Transitionscene());
              
            }
            IEnumerator Transitionscene()
            {
                DontDestroyOnLoad(gameObject);

                yield return SceneManager.LoadSceneAsync(sonrakilevel);
                DontDestroyOnLoad(gameObject);

                CanvasFader fader = FindObjectOfType<CanvasFader>();
               yield return   fader.canvasartýr(canvasartýrzamaný);

                Portalcontroller otherportal = Getotherportal();
                Updateplayer(otherportal);

                yield return new WaitForSeconds(sahnebeklemezamaný);
                yield return fader.canvasazalt(canvasazaltzamaný);
                
                print("sahne yüklendi");
                Destroy(gameObject);
            }
            void Updateplayer(Portalcontroller otherportal )
            {
                GameObject player = GameObject.FindWithTag("Player");
                player.GetComponent<NavMeshAgent>().Warp(otherportal.spawnpoint.position);
                player.transform.rotation = otherportal.spawnpoint.rotation;
            }
            
             Portalcontroller Getotherportal()
            {
                foreach (Portalcontroller portal in FindObjectsOfType<Portalcontroller>())
                {
                    if (portal == this) continue;
                    if (portal.destination != destination) continue;

                    return portal;
                }
                return null;
            }
                
        }



    }
}

