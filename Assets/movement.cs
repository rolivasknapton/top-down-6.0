using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    
    private float rotationSpeed;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();

        if (CanMove())
        {
            transform.Translate(movementDirection * speed * inputMagnitude * Time.deltaTime, Space.World);
            
            if (movementDirection != Vector2.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);

                //look rotation dependant on the speed of modifier
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
                
                //instantaneous
                transform.rotation = Quaternion.Normalize( toRotation);

            }
        }
        
        
    }
    private bool CanMove()
    {
        
        bool canattack = true;

        if (this.GetComponent<PlayerAttack>().Attacking == true)
        {
            canattack = false;
        }
        return canattack;
       
    }
    
}