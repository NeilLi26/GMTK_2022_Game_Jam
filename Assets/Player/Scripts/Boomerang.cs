using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour {
    [SerializeField] private Transform player;
    [SerializeField] private float boomerangSpeed;
    [SerializeField] private float maxTime;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private LayerMask playerLayer;
    public Camera camera;
    private bool hasHit;
    private float lifetime;

    void Start() {
        hasHit = false;
        lifetime = 0;
    }

    private void Update() {
        if (hasHit || lifetime >= maxTime) {
            gameObject.SetActive(false);
            hasHit = false;
            lifetime = 0;
            return;
        }
        CheckForCollisions();

    }

    private void CheckForCollisions() {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);
        foreach (Collider2D enemy in enemies) {
            hasHit = true;
            // TODO: damage enemy
            Debug.Log("hit enemy");
        }
    }

    public IEnumerator boomerangAttack() {
        Vector2 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 projectileVector = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        projectileVector = projectileVector.normalized;
        projectileVector *= 10f;

        lifetime = 0;
        while (!hasHit && lifetime < maxTime) {
            lifetime += Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, projectileVector, boomerangSpeed * Time.deltaTime);

            yield return null;
        }

    }

}
