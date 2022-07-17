using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    [SerializeField] public float maxHealth;
    public float currHealth;
    [SerializeField] DeathMenu deathMenu;
    public bool Invincible;
    private bool isDead;

    void Start() {
        Invincible = false;
        currHealth = maxHealth;
        isDead = false;
    }

    void Update() {
        if (currHealth == 0 && !isDead) {
            Die();
        }
    }

    private void Die() {
        // TODO: set death animation and disable object? reset level? game over?
        Debug.Log("DIE");
        isDead = true;
        //TODO: set death animation here, wait time, then deathMenu
        Invincible = true;
        deathMenu.Pause();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            // TODO: update this value?
            TakeDamage(1);
        }
    }

    public void TakeDamage(float damage) {
        if (!Invincible)
        {
            Debug.Log("oh no took damage");
            currHealth -= damage;
            currHealth = Mathf.Clamp(currHealth, 0, maxHealth);
            Debug.Log(currHealth);

            //TODO: animation for taking damage?
            StartIFrame();
        }
    }

    public void Heal(float amount) {
        Debug.Log("healing :3");
        currHealth += amount;
        currHealth = Mathf.Clamp(currHealth, 0, maxHealth);
        Debug.Log(currHealth);

        // TODO: animation for healing?
    }

    public void StartIFrame()
    {
        Debug.Log(Invincible);
        // TODO: invincible animation
        Invincible = true;
        Invoke("EndIFrame", 1);
    }

    void EndIFrame()
    {
        Invincible = false ;
    }
}
