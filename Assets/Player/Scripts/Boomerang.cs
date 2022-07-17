using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour {
    [SerializeField] private float maxTime;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private LayerMask playerLayer;
    private bool hasHit;
    private float lifetime;

    void Start() {
        hasHit = false;
        lifetime = 0;
    }

    private void Update() {
        if (hasHit || lifetime >= maxTime) {
            Destroy(gameObject);
            hasHit = false;
            lifetime = 0;
            return;
        }
        CheckForCollisions();
        lifetime += Time.deltaTime;

    }

    private void CheckForCollisions() {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);
        foreach (Collider2D enemy in enemies) {
            
            if (enemy.gameObject.tag == "Enemy") {
                hasHit = true;
                enemy.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
            }
        }
    }

}
