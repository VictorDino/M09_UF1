using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeDamage : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<HealthDamage>().getDamage(damage);
        }

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<HealthDamage>().getDamage(damage);
        }

    }

   
}
