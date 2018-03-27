using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalagaGameManager : MonoBehaviour {

    public static GalagaGameManager instance;

    public GameObject[] playerShipIconList;

    private int playerLives;

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

    public void OnShipHited()
    {
        playerLives--;
        playerShipIconList[playerLives].SetActive(false);
        if (playerLives == 0)
            gameOver();
    }

    private void gameOver()
    {
        throw new NotImplementedException();
    }
}
