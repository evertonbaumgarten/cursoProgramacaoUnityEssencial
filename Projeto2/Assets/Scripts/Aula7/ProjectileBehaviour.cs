using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour {
    public float distance;
    private bool moving = false;
    private Vector2 shootPosition;

    private void Update()
    {
        if (moving && Vector2.Distance(transform.position, shootPosition) > distance)
            Destroy(gameObject);
    }

    public void Shoot(Vector2 startPosition, Vector2 direction, float speed)
    {
        shootPosition = startPosition;
        transform.position = shootPosition;
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        moving = true;
    }

}
