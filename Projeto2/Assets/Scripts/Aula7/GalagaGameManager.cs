using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalagaGameManager : MonoBehaviour {
    
    public static GalagaGameManager instance;


    public enum AlienType { AlienA, AlienB, AlienC, AlienD };
    public GameObject[] alienFormationList;
    public GameObject[] alienList;
    public GameObject[] playerShipIconList;
    public Transform enemiesCanvas;

    public int LevelId = 0;

    protected int playerLives;
    protected Transform activeFormation;

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

        //Cria a formação de acordo com o level
        activeFormation = Instantiate<GameObject>(alienFormationList[LevelId]).transform;
        //Atribui o canvas como parent do transform. Coloca ele dentro do canvas na arquitetura.
        activeFormation.parent = enemiesCanvas.transform;
        //Posiciona a formação no centro do canvas. Atenção para a atribução da localposition ao invés da position
        activeFormation.localPosition = Vector3.zero;

        createEnemies();
    }

    protected void createEnemies()
    {
        
        //Itera por todos os filhos, pois o transform possui nativamente um GetIterator com seus filhos.
        foreach (Transform item in activeFormation)
        {
            int alienType = (int)item.gameObject.GetComponent<AlienPositionSetupBehaviour>().alienType;
            GameObject alien = Instantiate(alienList[alienType]);
            alien.transform.localPosition = Vector3.zero;
            alien.transform.parent = item;
        }
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
