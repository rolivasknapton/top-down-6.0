using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;

    private bool invulnerable = false;
    public bool Invulnerable => invulnerable;
    private int MAX_HEALTH = 100;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            // Damage(10);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            // Heal(10);
        }
    }
    
    public void Damage(int amount)
    {
        if (invulnerable == false)
        {
            if (amount < 0)
            {
                throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
            }

            this.health -= amount;

            if (health <= 0)
            {
                Die();
            }
        }
        
    }
    public void iFrameActivation(int time)
    {

        StartCoroutine(iFrames(time));
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }

        bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;

        if (wouldBeOverMaxHealth)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
    }

    private void Die()
    {
        Debug.Log("I am Dead!");
        Destroy(gameObject);
    }
    private IEnumerator iFrames(int time)
    {
        invulnerable = true;
        
        if(this.gameObject.name != "Triangle")
        {
            this.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f, .5f);
            //this.GetComponent<CircleCollider2D>().enabled = false;
            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
        if (this.gameObject.name == "Triangle")
        {
            this.GetComponent<SpriteRenderer>().color = new Color(255, 255f, 255f, .5f);
        }
        
        
        yield return new WaitForSeconds(time);
        invulnerable = false;
        if (this.gameObject.name != "Triangle")
        {
            this.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f, 1f);
        }
        if (this.gameObject.name == "Triangle")
        {
            this.GetComponent<SpriteRenderer>().color = new Color(255, 255f, 255f, 1f);
        }
        //this.GetComponent<CircleCollider2D>().enabled = true;
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
}
