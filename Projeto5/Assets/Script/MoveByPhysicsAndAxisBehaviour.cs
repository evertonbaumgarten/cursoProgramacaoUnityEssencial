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

        if (xDirection != 0)
        {
            rb2d.velocity = new Vector2(xDirection * speed, rb2d.velocity.y);
            //Vira o personagem para o lado correto
            if (xDirection > 0)
                transform.rotation = Quaternion.Euler(0, 0, 0);
            else
                transform.rotation = Quaternion.Euler(0, 180,0);
        }

        if (Input.GetAxis("Jump") == 1 && anim.GetBool("grounded"))
        {
            rb2d.AddForce(Vector2.up * jumpDistance);
            anim.SetTrigger("jump");
            Debug.Log(">>> JUMP!");
            
        }

        if (rb2d.velocity.x != 0 && anim.GetBool("grounded"))
            anim.SetBool("walk", true);
        else
            anim.SetBool("walk", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.tag);
        if (collision.collider.tag == "Ground")
            anim.SetBool("grounded", true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log(collision.collider.tag);
        if (collision.collider.tag == "Ground")
            anim.SetBool("grounded", false);
    }

}
