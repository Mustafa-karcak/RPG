using UnityEngine;

namespace RPG.Combat
{
    public class pickup : MonoBehaviour
    {
        [SerializeField] Weapon weapon = null;
        private void OnTriggerEnter(Collider other)
        {
          
            if(other.gameObject.tag == "Player")

            {
               other.GetComponent<Fighter>().SpawnWeapon(weapon);
                Destroy(gameObject);
            }
                
               
            
            
        }


    }
}
