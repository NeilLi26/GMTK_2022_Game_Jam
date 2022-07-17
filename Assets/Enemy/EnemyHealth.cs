using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public float maxHealth;
    public float currHealth;

    void Start() {
        currHealth = maxHealth;
    }

    void Update() {
        if (currHealth == 0) {
            Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            // TODO: update this value?
            TakeDamage(1);
        }
    }

    public void TakeDamage(float damage) {
        currHealth -= damage;
        currHealth = Mathf.Clamp(currHealth, 0, maxHealth);
        Debug.Log(currHealth);
    }
}
