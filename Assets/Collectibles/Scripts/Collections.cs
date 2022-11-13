using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collections : MonoBehaviour
{

    HealthDamage healthdamage;

    private void Start()
    {
        healthdamage = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthDamage>();
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 30) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            healthdamage.starQuantity = healthdamage.starQuantity + 1;
            Destroy(gameObject);
        }
    }
}
