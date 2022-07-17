using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float movementSpeed;
    [SerializeField] private float dashSpeed;
    private SpriteRenderer sprite;
    private Animator animator;
    private Rigidbody2D body;
    public Camera camera;

    void Start() {
        sprite = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        body.isKinematic = false;
    }

    void Update() {
        Move();

        // left shift for dash
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            Debug.Log("left shift");
            Dash();
        }
    }

    // move using wasd or arrow keys
    private void Move() {
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        body.velocity = move * movementSpeed;

        // flips the sprite depending on orientation
        if (Input.GetAxis("Horizontal") < 0) {
            transform.localScale = new Vector3(-1, 1, transform.position.z);
        } else if (Input.GetAxis("Horizontal") > 0) {
            transform.localScale = new Vector3(1, 1, transform.position.z);
        }

        // set moving animation
        animator.SetBool("isMoving", body.velocity != Vector2.zero);
    }

    // player dashes in direction arrow keys
    private void Dash() {
        Vector2 dashVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        body.AddForce(dashVector * dashSpeed);

        //trigger dash animation
        animator.SetTrigger("dash");
    }

}
