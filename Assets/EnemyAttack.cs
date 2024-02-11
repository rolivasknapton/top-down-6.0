using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private int damage = 50;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.tag == "Player" && collider.GetComponentInParent<Health>().Invulnerable == false && this.GetComponentInParent<Health>().CanAttack != false)
        {
            //Debug.Log("gay");
            GameObject enemy = collider.gameObject;
            //target = collider.transform;
            Health health = collider.GetComponentInParent<Health>();
            health.Damage(damage);


            AttackDebuffs(enemy);

        }
    }
    private void AttackDebuffs(GameObject enemyhit)
    {
        //IEnumerator Coroutine = enemyhit.GetComponent<EnemyFollow>().stunlocked(1);
        //StartCoroutine(Coroutine);

        var time = 1;
        //enemyhit.GetComponent<EnemyFollow>().Damaged(time);
        if (enemyhit.GetComponentInParent<EnemyFollow>() != null)
        {
            enemyhit.GetComponentInParent<EnemyFollow>().Damaged(time);
        }
        enemyhit.GetComponentInParent<Health>().iFrameActivation(time);
        //enemyhit.GetComponentInParent<PlayerMovement>().PlayerKnockBack(time, enemyhit);
        enemyhit.GetComponentInParent<PlayerMovement>().PlayerKnockBack(time, this.gameObject);




    }
}
