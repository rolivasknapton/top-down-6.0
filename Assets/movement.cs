using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private bool dashing =false;
    public bool Dashing_Property => dashing;
    private float dashTime = .5f;

    private bool damagedFramesActive;
    
    //que idk if it will work
    [SerializeField]
    private bool dashQueue = false;

    private float rotationSpeed;
    private Vector2 currentDirectionFacing;
    private Vector2 dodgeQueueDirection;
    private Quaternion directionFacing;


    private Vector2 knockbackdirection;
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();

        if (CanMove())
        {
            //queue logic 
            



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
            if (Input.GetKeyUp(KeyCode.JoystickButton1) ||Input.GetKeyUp(KeyCode.Z) || dashQueue)
            {                
                currentDirectionFacing = movementDirection;
                if (dashQueue)
                {
                    currentDirectionFacing = dodgeQueueDirection;
                }
                StartCoroutine(Dashing());
                this.GetComponent<Health>().iFrameActivation(dashTime);
                dashQueue = false;
            }
           
        }

        //more que logic
        //if (CanMove() == false && Input.GetKeyUp(KeyCode.JoystickButton1))
        //{
        //    currentDirectionFacing = movementDirection;
        //    dashQueue = true;
        //}
        if(CanMove() == false&& (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.Z)))
        {
            
                dashQueue = true;
            dodgeQueueDirection = movementDirection;
            
        }
        if (dashing)
        {

            Dash(currentDirectionFacing);
           

        }
        if (damagedFramesActive)
        {
            DamageMovement(knockbackdirection);
        }
        

        
        
        
    }
    
    public bool CanMove()
    {
        
        bool canattackormove = true;


        if (this.GetComponent<PlayerAttack>().Attacking == true)
        {
            canattackormove = false;
        }
        if (dashing == true)
        {
            canattackormove = false;
        }
        if (this.GetComponent<Health>().Invulnerable)
        {
            canattackormove = false;

        }
        if (damagedFramesActive)
        {
            canattackormove = false;
        }

        return canattackormove;
       
    }

    
    public void PlayerKnockBack(int time, GameObject attacker)
    {
        knockbackdirection = transform.position - attacker.transform.position;
        //knockbackdirection.Normalize();
        StartCoroutine(knock(time));
        
    }
    private IEnumerator knock(int time)
    {
        damagedFramesActive = true;
        
        yield return new WaitForSeconds(time);
        damagedFramesActive = false;
        //knockbackdirection = default;
       
    }

    private void DamageMovement(Vector2 knockbackdirection)
    {
        Debug.Log(knockbackdirection);
        //Debug.Log(this.transform.position);
        transform.Translate(knockbackdirection * 5  * Time.deltaTime, Space.World);
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