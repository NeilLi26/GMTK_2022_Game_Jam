using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour {
    [SerializeField] private Transform player;
    [SerializeField] private float boomerangSpeed;
    [SerializeField] private float maxTime;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private LayerMask playerLayer;
    public Camera camera;
    private bool hasReturned;

    void Start() {
        hasReturned = true;
    }

    private void Update() {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);
        foreach (Collider2D enemy in enemies) {
            // TODO: damage enemy
            Debug.Log("hit enemy");
        }
        Collider2D player = Physics2D.OverlapCircle(transform.position, attackRange, playerLayer);
        if (!hasReturned && player != null) {
            hasReturned = true;
            gameObject.SetActive(false);
        }
    }

    public IEnumerator boomerangAttack() {
        
        transform.position = player.transform.position;
        Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z;

        while (transform.position != mousePosition) {
            Vector3 currentPos = transform.position;
            float time = Vector3.Distance(currentPos, player.position) / (boomerangSpeed) * Time.deltaTime;

            transform.position = Vector3.MoveTowards(currentPos, mousePosition, time);

            yield return null;
        }

        StartCoroutine(boomerangReturn());
        
    }

    public IEnumerator boomerangReturn() {
        hasReturned = false;

        float timer = 0;

        while (!hasReturned && timer < maxTime) {
            Vector3 currentPos = transform.position;
            timer += Time.deltaTime;
            Debug.Log(timer);
            float time = Vector3.Distance(currentPos, player.position) / (boomerangSpeed) * Time.deltaTime;

            transform.position = Vector3.MoveTowards(currentPos, player.position, time);

            yield return null;
        }

        hasReturned = true;
        gameObject.SetActive(false);
    }

}
