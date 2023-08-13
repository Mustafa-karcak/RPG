using RPG.core;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RPG.Combat
{
    [CreateAssetMenu(fileName = "weapon",menuName = "Weapons/Make new weapon",order =0)]  
    
    public class Weapon : ScriptableObject
    {
        [SerializeField] GameObject weaponprefab = null;  
        [SerializeField] AnimatorOverrideController animatorOverrideController = null;
        [SerializeField] float weaponRange = 3f;
        [SerializeField] float ikisald�r�aras�s�re = 2f;
        [SerializeField] float hasar = 5f;
        [SerializeField] bool ishanded = true;
        [SerializeField] projecttiles projectile = null;

        public void Spawn(Transform righthand,Transform lefthand,Animator animator)
        {
        
            if(weaponprefab != null)
            {
                Transform handtransform = TransformHand(righthand, lefthand);
                Instantiate(weaponprefab, handtransform);
            }

            if (animatorOverrideController != null)
            {
                animator.runtimeAnimatorController = animatorOverrideController;
            }
        }
        Transform TransformHand(Transform righthand, Transform lefthand)
        {
            Transform handtransform;
            if (ishanded) handtransform = righthand;
            else handtransform = lefthand;
            return handtransform;
        }

        public bool Hasprojecttile()
          {
            return projectile != null;

          }
        public void LaunchProjecttile(Transform righthand,Transform lefthand,Health target)
        {
            projecttiles projectile�nstantie = Instantiate(projectile, TransformHand(righthand,lefthand).position,Quaternion.identity);
            projectile�nstantie.SetTarget(target);


        }



        public float Getdamage()
        {
            return hasar;
        }
        public float Getrange()
        {
            return weaponRange;
        }
        public float GetChange()
        {
            return ikisald�r�aras�s�re;
        }


    }

}

    
    
