using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class d8Behaviour : MonoBehaviour
{

    private enum State {
        moving,
        firing,
    }

    public float speed;
    public float projectileSpeed;
    public float minDist;
    public float Cooldown;
    public WindupBehaviour WindupPrefab;
    public Transform WindupOffset;
    private GameObject player;
    private State state;
    private float firingTime;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        state = State.moving;
        firingTime = Time.time + Cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > firingTime)
            state = State.firing;
        switch (state) {
            default:
            case State.moving:
                if (Vector3.Distance(transform.position, player.transform.position) > minDist) {
                    transform.Translate((player.transform.position - transform.position).normalized * speed * Time.deltaTime);
                } else {
                    transform.Translate((player.transform.position + transform.position).normalized * speed * Time.deltaTime);
                }
            break;
            case State.firing:
                Instantiate(WindupPrefab, WindupOffset.position, transform.rotation);
                state = State.moving;
                firingTime = Time.time + Cooldown;
            break;
        }
    }
}
