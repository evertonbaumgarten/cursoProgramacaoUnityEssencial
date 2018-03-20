using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallBehaviour : MonoBehaviour {

	// Use this for initialization
	public float startSpeed;
    public GameManagerBehaviour gameManager;

	void Start () {

        //Aplica uma força de 10 vezes para diagonal direita superior.
		GetComponent<Rigidbody2D>().velocity = (Vector2.up+Vector2.right)*startSpeed;
        //Modifica a influência da gravidade sobre este corpo para que ele se comporte como esperado.
        //GetComponent<Rigidbody2D>().gravityScale = 0.01f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Floor")
            SceneManager.LoadScene("GameOver");
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall")
            gameManager.addPoint(10);
        else if (collision.collider.tag == "Brick")
            gameManager.addPoint(20);
    }
}
