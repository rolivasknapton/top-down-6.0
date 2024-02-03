using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private bool dashing =false;
    private float dashTime = .5f;


    private float rotationSpeed;
    private Vector2 currentDirectionFacing;
    private Quaternion directionFacing;

    private void Start()
    {
        
    }
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

            //dashing implementation
            if (Input.GetKeyUp(KeyCode.JoystickButton1))
            {
                
                currentDirectionFacing = movementDirection;
                
                StartCoroutine(Dashing());
                this.GetComponent<Health>().iFrameActivation(dashTime);
                
            }
        }

        if (dashing)
        {
            Dash(currentDirectionFacing);

        }
        
        
        
    }
    
    public bool CanMove()
    {
        
        bool canattack = true;


        if (this.GetComponent<PlayerAttack>().Attacking == true)
        {
            canattack = false;
        }
        if (dashing == true)
        {
            canattack = false;
        }
        return canattack;
       
    }
    
    public void Dash(Vector2 direction)
    {
        transform.Translate(direction * speed * 2 * Time.deltaTime, Space.World);
    }
    IEnumerator Dashing()
    {
        Debug.Log("dashing");
        dashing = true;
        yield return new WaitForSeconds(dashTime);
        Debug.Log("no longer dashing");
        dashing = false;

    }
    
}