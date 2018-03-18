using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBehaviour : MonoBehaviour {

    public GameObject paddle;
    public GameObject specialItemPrefab;
    public int specialItemInterval;

    // Use this for initialization
	void Start () {
        Invoke("createSpecialItem", 1);
        
    }
	
	protected void createSpecialItem()
    {
        GameObject specialItemTemp = Instantiate<GameObject>(specialItemPrefab);
        specialItemTemp.transform.position = new Vector2(Random.Range(-6, 6), Random.Range(-4, 1));
        specialItemTemp.GetComponent<SpecialItemBehaviour>().gameManager = this;
    }

    public void onSpecialItemCollision()
    {
        //Armazena o tamanho atual para modificar e atribuir ao parametro size que não permite escrita.
        Vector2 paddleCurrentSize = paddle.GetComponent<SpriteRenderer>().size;
        paddleCurrentSize.x += 1;
        //Atualiza tanto o tamanho do sprite como também o do collider.
        paddle.GetComponent<SpriteRenderer>().size = paddleCurrentSize;
        paddle.GetComponent<BoxCollider2D>().size = paddleCurrentSize;

        Invoke("createSpecialItem", 1);
    }
}
