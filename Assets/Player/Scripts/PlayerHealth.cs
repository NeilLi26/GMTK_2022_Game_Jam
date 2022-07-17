using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    [SerializeField] public float maxHealth;
    public float currHealth;
    [SerializeField] DeathMenu deathMenu;
    public bool Invincible;
    private bool isDead;
    private Animator anim;

    void Start() {
        Invincible = false;
        currHealth = maxHealth;
        isDead = false;
        anim = GetComponent<Animator>();
    }

    void Update() {
        if (currHealth == 0 && !isDead) {
            Die();
        }
    }

    private void Die() {
        isDead = true;
        anim.SetTrigger("isDead");
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<PlayerMovement>().enabled = false;
        StartCoroutine(Wait());
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            TakeDamage(1);
        }
    }

    public void TakeDamage(float damage) {
        if (!Invincible)
        {
            currHealth -= damage;
            currHealth = Mathf.Clamp(currHealth, 0, maxHealth);

            if (currHealth != 0) {
                anim.SetTrigger("isHurt");
            }
            StartIFrame();
        }
    }

    public void Heal(float amount) {
        currHealth += amount;
        currHealth = Mathf.Clamp(currHealth, 0, maxHealth);
        Debug.Log(currHealth);
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

    private IEnumerator Wait() {
        yield return new WaitForSeconds(2f);
        Invincible = true;
        deathMenu.Pause();

    }
}
