using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Camera camera;
    [SerializeField] private float attackDistance;
    [SerializeField] private GameObject boomerangObject;
    private Boomerang boomerang;
    //[SerializeField] private float boomerangSpeed;
    //[SerializeField] private float boomerangSmoothing;

    // Start is called before the first frame update
    void Start() {
        boomerangObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        // left click for melee attack
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("left click");
            MeleeAttack();
        }
        // right click for ranged attack
        if (Input.GetMouseButtonDown(1)) {
            Debug.Log("rightclick");
            Boomerang();
        }

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

    private void Boomerang() {
        boomerangObject.SetActive(true);
        boomerang = boomerangObject.GetComponent<Boomerang>();
        StartCoroutine(boomerang.boomerangAttack());
    }

    // TODO: remove after testing
    private void OnDrawGizmosSelected() {
        if (attackPoint == null) {
            return;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
