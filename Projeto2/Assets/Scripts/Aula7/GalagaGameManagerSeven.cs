using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GalagaGameManagerSeven : MonoBehaviour {
    
    public static GalagaGameManagerSeven instance;

    public GameObject[] playerShipIconList;

    protected int playerLives;

    //Awake é sempre chamado antes de qualquer método Start
    void Awake()
    {
        if (instance == null) //Se a variável estática estiver nula,
            instance = this; //Atribui o OBJETO GameManager a variável estática.
        else if (instance != this) //Se a variável for diferente de this, já foi criada antes
            Destroy(gameObject);//Destrói o objeto    
        DontDestroyOnLoad(gameObject);//Define que o objeto não deve ser destruído nas cargas
    }

    private void Start()
    {
        playerLives = playerShipIconList.Length;
    }

    public void OnShipHited(Collider2D collider)
    {
        playerLives--;
        playerShipIconList[playerLives].SetActive(false);
        
        //Destroi o projectile
        Destroy(collider.gameObject);

        if (playerLives == 0)
            gameOver();
    }

    public void OnAlienHited(GameObject alienGameObject, Collider2D collider)
    {

        //Destruir o Alien
        Destroy(alienGameObject);
        //Destruir a partícula que o acertou
        Destroy(collider.gameObject);

    }

    private void gameOver()
    {
        SceneManager.LoadScene(2);
    }
}
