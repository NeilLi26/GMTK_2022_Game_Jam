using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public GameObject player;
    public List<FallingDice> fallingDies;
    private bool falling;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        falling = false;

        for (int i = 0; i < fallingDies.Count; i++)
        {
            fallingDies[i].diceManager = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!falling)
        {
            DropDice(player.transform.position);
            falling = true;
        }
    }

    public void DiceFallen()
    {
        falling = false;
    }

    private void DropDice(Vector3 dropPos)
    {
        int dieFace = Random.Range(0, 6);

        Instantiate(fallingDies[dieFace], new Vector3 (dropPos.x, dropPos.y + 2, dropPos.z), player.transform.rotation);
    }
}
