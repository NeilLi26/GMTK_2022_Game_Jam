using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public float maxHealth;
    public float currHealth;
    public bool Invincible;

    void Start() {
        Invincible = false;
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
        // if (collision.gameObject.tag == "Enemy") {
        //     // TODO: update this value?
        //     TakeDamage(1);
        // }
    }

    public void TakeDamage(float damage) {
        if (!Invincible)
        {
            currHealth -= damage;
            currHealth = Mathf.Clamp(currHealth, 0, maxHealth);
            Debug.Log(currHealth);

            StartIFrame();
        }
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
