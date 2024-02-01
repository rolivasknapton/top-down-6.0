using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;
    public GameObject Attackarea => attackArea;
    //private GameObject focusedAttackArea = default;
    
    
    private bool attacking = false;
    
    public bool Attacking => attacking;
    

    [SerializeField]
    private float timeToAttack;
    private float timer = 0f;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject sword_swipe;
    public Transform playerposition;
    private bool canAttack;

    // Start is called before the first frame update
    void Start()
    {
        
       //attackArea = transform.GetChild(0).gameObject;
       //focusedAttackArea = transform.GetChild(1).gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            Attack();
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                if(attackArea != null)
                {
                    attackArea.SetActive(attacking);
                }
                
                //focusedAttackArea.SetActive(attacking);
            }

        }
    }

    private void Attack()
    {
        if (attacking == false)
        {
            Instantiate(sword_swipe, playerposition);
            //attackArea = transform.GetChild(0).gameObject;
            attacking = true;
            //attackArea.SetActive(attacking);
            //focusedAttackArea.SetActive(attacking);
        }
        
        //focusedAttackArea.SetActive(attacking);
        
        
        

    }
}
