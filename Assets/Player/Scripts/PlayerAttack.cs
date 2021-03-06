using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Camera camera;
    [SerializeField] private float attackDistance;
    [SerializeField] private float boomerangCD;
    [SerializeField] private RangedWeapon rangedWeapon;
    [SerializeField] private GameObject meleeWeapon;
    private Animator meleeAnimator;
    private float timer;

    void Start() {
        timer = Mathf.Infinity;
        meleeAnimator = meleeWeapon.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        // left click for melee attack
        if (Input.GetMouseButtonDown(0)) {
            MeleeAttack();
        }
        // right click for ranged attack
        if (Input.GetMouseButtonDown(1)) {
            if (timer > boomerangCD) {
                rangedWeapon.Throw();
                timer = 0;
            }
        }
        timer += Time.deltaTime;
    }

    // melee attack in the direction of mouse position
    private void MeleeAttack() {
        // play melee attack animation
        meleeAnimator.SetTrigger("isAttacking");

        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach(Collider2D enemy in enemies) {
            if (enemy.gameObject.tag == "Enemy") {
                enemy.gameObject.GetComponent<EnemyHealth>().TakeDamage(3);
            }
        }
        
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
