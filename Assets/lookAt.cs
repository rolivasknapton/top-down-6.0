using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAt : MonoBehaviour
{
    public Transform target;
    public float speed = 100f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        target = collision.transform;
        Debug.Log(target);
        lookAtWhenPressed(target);
    }
    public void lookAtWhenPressed(Transform _target)
    {
        Vector2 direction = _target.position - transform.position;
        float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg- 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        this.transform.parent.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed);  
    }
    
}
