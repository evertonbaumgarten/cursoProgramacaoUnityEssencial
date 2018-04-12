using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerByAxisBehaviour : MonoBehaviour {

    public static string EVENT_GO_DOWN = "goDown";
    public static string EVENT_GO_UP = "goUp";
    public static string EVENT_GO_RIGHT = "goRight";
    public static string EVENT_GO_LEFT = "goLeft";
    public static string EVENT_STOP = "stop";

    public Animator animator;

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


        if (direction.x > 0 && !animator.GetCurrentAnimatorStateInfo(0).IsName("WalkingRight"))
            animator.SetTrigger(EVENT_GO_RIGHT);
        else if (direction.x < 0 && !animator.GetCurrentAnimatorStateInfo(0).IsName("WalkingLeft"))
            animator.SetTrigger(EVENT_GO_LEFT);
        else if (direction.y > 0 && !animator.GetCurrentAnimatorStateInfo(0).IsName("WalkingUp"))
            animator.SetTrigger(EVENT_GO_UP);
        else if (direction.y < 0 && !animator.GetCurrentAnimatorStateInfo(0).IsName("WalkingDown"))
            animator.SetTrigger(EVENT_GO_DOWN);
        else if(rb2d.velocity.magnitude ==0)
            animator.SetTrigger(EVENT_STOP);
	}

}
