using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAt : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public focusedAttackAreaScript script;
    public PlayerAttack playerattackscript;
    private void Awake()
    {
        playerattackscript = this.transform.parent.GetComponent<PlayerAttack>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        target = collision.transform;
        playerattackscript.Attackarea.SetActive(false);
        Debug.Log(target);
        //Debug.Log(script.focusedTarget);

        //lookAtWhenPressed(target);

       

    }
    public void lookAtWhenPressed(Transform _target)
    {
        Vector2 direction = _target.position - transform.position;
        float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg- 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        ///turns the player direction towards the target
        //this.transform.parent.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed);  
        this.transform.parent.transform.rotation = Quaternion.Normalize(rotation);

        
    }
    
}
