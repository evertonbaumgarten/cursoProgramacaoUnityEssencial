using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalInputMovimentBehaviour : MonoBehaviour {

    public float speed = 0.1f;
    public float maxX, minX;

    private float width;

    private void Start()
    {
        width = GetComponent<SpriteRenderer>().size.x;    
    }
    // Update is called once per frame
    void Update () {
        Vector2 currentPosition = transform.position;

        if (Input.GetKey(KeyCode.RightArrow))
            currentPosition.x += speed;
        else if (Input.GetKey(KeyCode.LeftArrow))
            currentPosition.x -= speed;
        
        currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);

        transform.position = currentPosition;
    }
}
