using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindupBehaviour : MonoBehaviour
{

    public float projectileSpeed;
    public ProjectileBehaviour ProjectilePrefab;
    public Transform ProjectileOffset;
    private int x;

    // Start is called before the first frame update
    void Start()
    {
        x = 0;
    }

    // Update is called once per frame
    void Update()
    {
        x++;

        if (x > 200) {
            Instantiate(ProjectilePrefab, ProjectileOffset.position, ProjectilePrefab.transform.rotation);
            Destroy(gameObject);
        }
    }
}
