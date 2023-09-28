using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{
    private Rigidbody characterRb;

    private void Start()
    {
        characterRb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 targetPosition)
    {
        Vector3 moveDir = targetPosition - transform.position;

        float speed = 5f;
        characterRb.AddForce(moveDir * speed * Time.deltaTime, ForceMode.Impulse);
    }

    public static Vector3 ConstrainMovement(float xPosition, float yPosition)
    {        
        if (xPosition < -45)
        {
            return new Vector3(-45, 1, yPosition);
        }
        else if (xPosition > 45)
        {
            return new Vector3(45, 1, yPosition);
        }
        else if (yPosition < -38)
        {
            return new Vector3(xPosition, 1, -38);
        }
        else if (yPosition > 38)
        {
            return new Vector3(xPosition, 1, 38);
        }
        return new Vector3(xPosition, 1, yPosition);
    }
}
