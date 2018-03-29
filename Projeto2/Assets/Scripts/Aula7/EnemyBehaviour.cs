using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public GameObject projectilePrefab;
    public float projectileSpeed;

    private void Start()
    {
        Invoke("Attack", Random.Range(3, 15));
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Shoot")
        {
            //Se destroi
            Destroy(gameObject);
            //Destroi também o projétil
            Destroy(collider.gameObject);
        }
    }

    private void ShootPlayer()
    {
        GameObject projectileTemp = Instantiate<GameObject>(projectilePrefab);
        projectileTemp.GetComponent<ProjectileBehaviour>().Shoot(transform.position, Vector2.down, projectileSpeed);

        int random = Random.Range(3, 15);
        Invoke("Attack", random);
    }

    private void Attack()
    {
        GetComponent<Animator>().SetTrigger("attack");
        int random = Random.Range(3, 15);
        Invoke("ShootPlayer", random);
    }
}
