using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Camera camera;
    [SerializeField] private float attackDistance;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        // TODO: switch key if needed
        if (Input.GetKeyDown(KeyCode.Space)) {
            MeleeAttack();
        }

        // TODO: if something, ranged attack
    }

    // melee attack in the direction of mouse position
    private void MeleeAttack() {
        // TODO: play melee attack animation


        Vector3 playerPosition = transform.position;
        Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 playerToMouse = new Vector3(mousePosition.x - playerPosition.x, mousePosition.y - playerPosition.y, playerPosition.z);
        playerToMouse = playerToMouse.normalized;
        playerToMouse *= attackDistance;

        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position + playerToMouse, attackRange, enemyLayer);
        foreach(Collider2D enemy in enemies) {
            // TODO: damage enemy
            Debug.Log("hit enemy");
        }
    }

    // TODO: remove after testing
    private void OnDrawGizmosSelected() {
        if (attackPoint == null) {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
