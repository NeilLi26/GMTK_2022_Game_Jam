using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDice : MonoBehaviour
{
    // gameobjects
    public GameObject shadow;
    public GameObject dice;
    public DiceManager diceManager;
    public int dieFace;

    private BoxCollider2D boxCollider;

    // animatiosn
    /*
    public Animation shadowGrowing;
    public Animation diceFalling;
    */
    public Animator animator;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        shadow = transform.Find("Shadow").gameObject;
        dice = transform.Find("Dice").gameObject;
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;

        //getting animations
        animator = gameObject.GetComponent<Animator>();

        /*
        shadow.SetActive(true);
        */
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();


        Invoke("DropDice", 1 + (((float) dieFace)/2));
    }

    // Update is called once per frame
    void Update()
    {
    }

    void DropDice()
    {
        animator.SetBool("Dropped", true);
        spriteRenderer.sortingOrder = 6;
        /*
        shadow.SetActive(false);
        dice.SetActive(true);
        */
        boxCollider.enabled = true;

        Invoke("DespawnDice", 0.5f);
    }

    void DespawnDice()
    {
        dice.SetActive(false);
        diceManager.DiceFallen();
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("hit");
            PlayerHealth ph = collision.GetComponent<PlayerHealth>();
            ph.TakeDamage(dieFace);
        }
        if (collision.CompareTag("Enemy")) {
            EnemyHealth eh = collision.GetComponent<EnemyHealth>();
            eh.TakeDamage(dieFace);
        }
    }
}
