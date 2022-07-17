using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour {
    [SerializeField] private Camera camera;
    public GameObject boomerang;
    public Transform shootingPoint;
    public float boomerangForce;
    private Transform player;

    // Start is called before the first frame update
    void Start() {
        player = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update() {
        Rotate();
    }

    private void Rotate() {
        Vector2 direction = camera.ScreenToWorldPoint(Input.mousePosition) - player.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void Throw() {
        GameObject projectile = Instantiate(boomerang, shootingPoint.position, shootingPoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(shootingPoint.up * boomerangForce, ForceMode2D.Impulse);
    }
}
