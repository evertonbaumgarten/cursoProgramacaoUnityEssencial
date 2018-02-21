using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //Aplica uma forma de 10 vezes para cima.
        GetComponent<Rigidbody2D>().velocity = Vector2.up*10;
        //Modifica a influência da gravidade sobre este corpo para que ele se comporte como esperado.
        //GetComponent<Rigidbody2D>().gravityScale = 0.01f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.collider.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
    }
}
