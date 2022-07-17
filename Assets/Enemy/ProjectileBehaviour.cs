using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float speed;
    private GameObject player;
    private Vector3 target;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        target = player.transform.position;
        timer = Time.time + 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((target - transform.position).normalized * speed * Time.deltaTime);
        if (Time.time > timer) {
            Destroy(gameObject);
        }
    }

    void onCollisionEnter2D(Collision2D collision) {
        Debug.Log("hit");
        Destroy(gameObject);
    }
}
