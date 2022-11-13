using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    
    public Rigidbody rigidbody;

    public Transform[] platformPositions;

    public float platformSpeed = 15;

    private int currentPosition = 0;
    private int nextPosition = 1;
   
    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        rigidbody.MovePosition(Vector3.MoveTowards(rigidbody.position, platformPositions[nextPosition].position, platformSpeed * Time.deltaTime));
        
        if (Vector3.Distance(rigidbody.position,platformPositions[nextPosition].position) <= 0)
        {
            currentPosition = nextPosition;
            nextPosition++;
        }

        if (nextPosition> platformPositions.Length -1)
        {
            nextPosition = 0;
        }
    }
}
