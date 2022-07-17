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
    [SerializeField] private float boomerangDistance;
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
            return;
        }


        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);
        foreach (Collider2D enemy in enemies) {
            hasHit = true;
            // TODO: damage enemy
            Debug.Log("hit enemy");
        }
    }

    public IEnumerator boomerangAttack() {

        transform.position = player.transform.position;
        Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z;

        lifetime = 0;

        while (!hasHit && lifetime < maxTime) {
            lifetime += Time.deltaTime;
            Vector3 currentPos = transform.position;
            float time = Vector3.Distance(currentPos, mousePosition) / (boomerangSpeed) * Time.deltaTime;

            transform.position = Vector3.MoveTowards(currentPos, mousePosition, time);

            yield return null;
        }

    }

}
