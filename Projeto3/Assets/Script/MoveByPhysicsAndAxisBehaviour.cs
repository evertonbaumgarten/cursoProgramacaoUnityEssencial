using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByPhysicsAndAxisBehaviour : MonoBehaviour {

    public float speed;
    public float jumpDistance;

    protected bool jumping=false;
    protected float xDirection;
    protected Rigidbody2D rb2d;
    protected Animator anim;

    private void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate () {

        xDirection = Input.GetAxis("Horizontal");

        if(xDirection != 0)
            rb2d.velocity = new Vector2 (xDirection * speed, rb2d.velocity.y) ;

        if (Input.GetAxis("Jump") == 1 && !anim.GetBool("jump"))
            rb2d.AddForce(Vector2.up * jumpDistance);



        //Debug.Log(GetComponent<Rigidbody2D>().velocity);

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.tag);
        if (collision.collider.tag == "Ground")
            anim.SetBool("jump", false);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
            anim.SetBool("jump", true);
    }
}
