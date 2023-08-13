using RPG.core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projecttiles : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    
    Health target = null;

    
      
    public void SetTarget(Health Target)
    {
        this.target = Target;
    }
    void Update()
    {
        if (target == null) return; 
        transform.LookAt(targetLocation());
        transform.Translate(Vector3.forward * speed * Time.deltaTime); 
    }

    private Vector3 targetLocation()
    {
      CapsuleCollider targetcapsule = target.GetComponent<CapsuleCollider>();
      if(targetcapsule == null)
        {
            return target.transform.position;
        }
        
        return target.transform.position + Vector3.up * targetcapsule.height / 2;


    }
}
