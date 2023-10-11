using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    
    public Transform nuevoLugar; 
    
    void Start()
    {
        
        
    }

    void OnTriggerEnter(Collider other)
    {   
        if(other.tag == "pared")
        {
            transform.position = new Vector3(0f, 4.237f, 0.6f);
        }
     }

    void Update()
    {
        
    }
}
