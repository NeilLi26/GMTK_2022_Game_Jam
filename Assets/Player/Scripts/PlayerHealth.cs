using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
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
        // TODO: set death animation and disable object? reset level? game over?
        Debug.Log("DIE");

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            // TODO: update this value?
            TakeDamage(1);
        }
        /* TODO: remove this (for testing the healing)
        if (collision.gameObject.tag == "Heal") {
            Heal(1);
        }
        */
    }

    public void TakeDamage(float damage) {
        Debug.Log("oh no took damage");
        currHealth -= damage;
        currHealth = Mathf.Clamp(currHealth, 0, maxHealth);
        Debug.Log(currHealth);

        //TODO: animation for taking damage?
    }

    public void Heal(float amount) {
        Debug.Log("healing :3");
        currHealth += amount;
        currHealth = Mathf.Clamp(currHealth, 0, maxHealth);
        Debug.Log(currHealth);

        // TODO: animation for healing?
    }

    // TODO: iframe
}
