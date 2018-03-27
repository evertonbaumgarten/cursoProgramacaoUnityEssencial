using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingProjetile2DBehaviour : MonoBehaviour {

    public GameObject projectilePrefab;
    public float projectileSpeed;


    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projectileTemp = Instantiate<GameObject>(projectilePrefab);
            projectileTemp.GetComponent<ProjectileBehaviour>().Shoot(transform.position, Vector2.up, projectileSpeed);
        }
    }
}
