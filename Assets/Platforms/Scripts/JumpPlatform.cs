using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {

            other.gameObject.GetComponent<PlayerMove>().jumpOnPlatform();
            
            
            
        }
    }
}
