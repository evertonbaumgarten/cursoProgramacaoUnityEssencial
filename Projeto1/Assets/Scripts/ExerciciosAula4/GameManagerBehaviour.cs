using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerBehaviour : MonoBehaviour {

    public GameObject paddle;
    public GameObject specialItemPrefab;
    public int specialItemInterval;
    public Text scorePanel;

    private int totalPoints = 0;

    // Use this for initialization
    void Start () {
        Invoke("createSpecialItem", 1);
        //scorePanel.text = totalPoints.ToString();
    }
	
	protected void createSpecialItem()
    {
        GameObject specialItemTemp = Instantiate<GameObject>(specialItemPrefab);
        specialItemTemp.transform.position = new Vector2(UnityEngine.Random.Range(-6, 6), UnityEngine.Random.Range(-4, 1));
       // specialItemTemp.GetComponent<SpecialItemBehaviour>().gameManager = this;
    }

    public void gameOver()
    {
        SceneManager.LoadScene("Scenes/ExerciciosAula4/GameOver", LoadSceneMode.Single);
    }

    public void onSpecialItemCollision()
    {
        //Armazena o tamanho atual para modificar e atribuir ao parametro size que não permite escrita.
        Vector2 paddleCurrentSize = paddle.GetComponent<SpriteRenderer>().size;
        paddleCurrentSize.x += 1;
        //Atualiza tanto o tamanho do sprite como também o do collider.
        paddle.GetComponent<SpriteRenderer>().size = paddleCurrentSize;
        paddle.GetComponent<BoxCollider2D>().size = paddleCurrentSize;

        Invoke("createSpecialItem", 5);
    }

    public void onBallHit(Collider2D collider)
    {
        print(">>> " + collider.name);
        if (collider.tag == "Wall")
            addPoint(10);
        else if (collider.tag == "Brick")
            addPoint(20);
        else if (collider.name == "Floor")
            gameOver();
        else if (collider.tag == "SpecialItem")
        {
            onSpecialItemCollision();
            Destroy(collider.gameObject);
        }
    }

    public void addPoint(int point)
    {
        totalPoints += point;
        scorePanel.text = totalPoints.ToString();
    }
}
