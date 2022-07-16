using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    [SerializeField] private Transform player;
    [SerializeField] private float cameraSmoothing;

    void Update() {
        Vector2 newPos = Vector2.Lerp(transform.position, player.position, cameraSmoothing);
        transform.position = new Vector3(newPos.x, newPos.y, transform.position.z) ;
    }
}
