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
            hasHit = true;
            // TODO: damage enemy
            Debug.Log("hit enemy");
        }
    }

    /*
    public IEnumerator boomerangAttack() {
        transform.position = Vector2.zero;
        Vector2 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 projectileVector = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        projectileVector = projectileVector.normalized;
        projectileVector *= 5f;

        lifetime = 0;
        while (!hasHit && lifetime < maxTime) {
            lifetime += Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, projectileVector, boomerangSpeed * Time.deltaTime);

            yield return null;
        }

    }
    */

}
