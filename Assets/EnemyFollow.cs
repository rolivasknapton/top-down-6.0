using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform player;
    private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    [SerializeField]
    private bool canMove;

    private bool attacking;
    private float timer;
    [SerializeField]
    private float timetoattack;

    private Transform thisEnemyPosition;
    public GameObject sword_swipe;

    private bool stunned;
    private Vector2 attackDirection;
   
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;

        thisEnemyPosition = this.transform;

        rb = this.GetComponent<Rigidbody2D>();

        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        setDirectionOfMovementAndRotation();
        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timetoattack)
            {
                timer = 0;
                attacking = false;
            }
        }
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            moveCharacter(movement, moveSpeed);
        }
        if (stunned)
        {
            moveCharacter(attackDirection, 0.25f);
        }

    }
    private void setDirectionOfMovementAndRotation()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    void moveCharacter(Vector2 direction, float speed)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
    public void Damaged(int time)
    {
        //stuns the enemy for an amount of time
        StartCoroutine(stunlocked(time));

        //changes the appearance and the vulnerability for the same amount of time as is stunlocked

    }
    private IEnumerator stunlocked(int time)
    {
        canMove = false;
        attackDirection = movement * -1;
        stunned = true;

        yield return new WaitForSeconds(time);
        canMove = true;
        attackDirection = default;
        stunned = false;

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "stopEnemyZone")
        {
            
            canMove = false;
            if (attacking == false)
            {

                //Instantiate(sword_swipe, thisEnemyPosition);
                attacking = true;

            }
            

        }
       
        
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "stopEnemyZone")
        {

            canMove = true;

        }
       
    }

    
 
}
