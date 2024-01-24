using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 3;
    private Transform target;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>() != null)
        {
            target = collider.transform;
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
            //Debug.Log(target);
        }
    }
}
