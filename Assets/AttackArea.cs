using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField]
    private int damage = 50;
    //private Transform target;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>() != null && collider.GetComponent<Health>().Invulnerable == false)
        {

            GameObject enemy = collider.gameObject;
            //target = collider.transform;
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
            
            
            AttackDebuffs(enemy);
            
        }
    }
    private void AttackDebuffs(GameObject enemyhit)
    {
        //IEnumerator Coroutine = enemyhit.GetComponent<EnemyFollow>().stunlocked(1);
        //StartCoroutine(Coroutine);

        var time = 1;
        enemyhit.GetComponent<EnemyFollow>().Damaged(time);
        enemyhit.GetComponent<Health>().iFrameActivation(time);



    }
}
