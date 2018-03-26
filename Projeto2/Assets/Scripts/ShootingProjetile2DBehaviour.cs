using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingProjetile2DBehaviour : MonoBehaviour {

    public GameObject projectilePrefab;
    public Vector2 direction = Vector2.up;
    public Transform positionAgent;
    public float speed;

    // Update is called once per frame
    void Update () {
	    if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projectileTemp = Instantiate<GameObject>(projectilePrefab);
            projectileTemp.transform.position = positionAgent.position;
            if (projectileTemp.GetComponent<Rigidbody2D>())
                projectileTemp.GetComponent<Rigidbody2D>().velocity = direction * speed;
            else
                throw new MissingComponentException("Falta Rigidibody");
        }
            
	}
}
