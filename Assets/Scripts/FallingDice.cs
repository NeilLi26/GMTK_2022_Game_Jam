using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDice : MonoBehaviour
{
    public GameObject shadow;
    public GameObject dice;
    public DiceManager diceManager;
    public int dieFace;

    public BoxCollider2D boxCollider;


    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

        shadow = transform.Find("Shadow").gameObject;
        dice = transform.Find("Dice").gameObject;

        shadow.SetActive(true);
        boxCollider.enabled = false;

        Invoke("DropDice", 2 + (((float) dieFace)/2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DropDice()
    {
        shadow.SetActive(false);
        dice.SetActive(true);
        boxCollider.enabled = true;

        Invoke("DespawnDice", 0.5f);
    }

    void DespawnDice()
    {
        dice.SetActive(false);
        diceManager.DiceFallen();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("HIT");
        collision.gameObject.GetComponent<PlayerController>().RegisterHit();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("STAYED");
        collision.gameObject.GetComponent<PlayerController>().RegisterHit();
    }
}
