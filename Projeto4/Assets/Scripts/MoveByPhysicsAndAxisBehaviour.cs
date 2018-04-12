using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByPhysicsAndAxisBehaviour : MonoBehaviour {

    public static string EVENT_GO_DOWN = "goDown";
    public static string EVENT_GO_UP = "goUp";
    public static string EVENT_GO_RIGHT = "goRight";
    public static string EVENT_GO_LEFT = "goLeft";
    public static string EVENT_STOP = "stop";

    public float speed;
    public float jumpDistance;

    protected bool jumping=false;
    protected Rigidbody2D rb2d;
    protected Vector2 direction;
    

    private void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate () {

        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        rb2d.velocity = direction * speed;
	}

}
