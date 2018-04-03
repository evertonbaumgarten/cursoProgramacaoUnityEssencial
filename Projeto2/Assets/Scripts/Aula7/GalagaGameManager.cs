using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GalagaGameManager : MonoBehaviour {
    
    public static GalagaGameManager instance;

    public enum AlienType { AlienA, AlienB, AlienC, AlienD };

    public Text scorePanel;
    public GameObject[] alienFormationList;
    public GameObject[] alienList;
    public GameObject[] playerShipIconList;
    public Transform enemiesCanvas;
    public GameObject alienExplosionPrefab;
    public GameObject playerShip;

    public int LevelId = 0;

    protected int activeFormationIndex;
    protected int playerLives;
    protected Transform activeFormation;
    protected int currentAlienFleet;
    protected Dictionary<string,int> scoreTable;
    protected int totalScore;

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
        currentAlienFleet = 0;
        playerLives = playerShipIconList.Length;
        activeFormationIndex = 0;
        scoreTable = new Dictionary<string, int>();

        createFormation();
        createEnemies();
    }

    protected void createFormation()
    {
        //Cria a formação de acordo com o level
        activeFormation = Instantiate<GameObject>(alienFormationList[activeFormationIndex]).transform;
        //Atribui o canvas como parent do transform. Coloca ele dentro do canvas na arquitetura.
        activeFormation.parent = enemiesCanvas.transform;
        //Posiciona a formação no centro do canvas. Atenção para a atribução da localposition ao invés da position
        activeFormation.localPosition = Vector3.zero;
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
            currentAlienFleet++;
        }
    }

    public void OnShipHited(Collider2D collider)
    {
        playerLives--;
        playerShipIconList[playerLives].SetActive(false);
        
        //Destroi o projectile
        Destroy(collider.gameObject);

        playerShip.GetComponent<Animator>().SetTrigger("hited");

        if (playerLives == 0)
            gameOver();
    }

    public void OnAlienHited(GameObject alienGameObject, Collider2D collider)
    {
        #region ScoreTable
        //Utiliza como Key o nome do sprite.
        string alienType = alienGameObject.GetComponent<SpriteRenderer>().sprite.name;
        
        //Testa se já existe uma chave com o tipo do alien. Se já existe, só incrementa. Caso contrário, cria uma nova.
        if (scoreTable.ContainsKey(alienType))
            scoreTable[alienType] = scoreTable[alienType] + 1;
        else
            scoreTable.Add(alienType, 1);

        //Atualiza HUD com o valor.
        scorePanel.text = getTotalScore().ToString();
        #endregion

        //Cria a particula no mesmo local onde a nave alien está
        GameObject particleExplosion = Instantiate<GameObject>(alienExplosionPrefab);
        particleExplosion.transform.position = alienGameObject.transform.position;

        //Destruir o Alien
        Destroy(alienGameObject);
        //Destruir a partícula que o acertou
        Destroy(collider.gameObject);
                
        currentAlienFleet--;
        if (currentAlienFleet == 0)
        {
            //Destroi a formação atual
            Destroy(activeFormation.gameObject);
            //troca para a próxima formação
            activeFormationIndex++;
            //Cria a formação
            createFormation();
            //Cria os aliens da formação
            createEnemies();
        }
    }

    public int getTotalScore()
    {
        int score = 0;
        foreach (var item in scoreTable)
            score += item.Value;
        return score;
    }

    public Dictionary<string, int> getScoreTable()
    {
        return scoreTable;
    }

    private void gameOver()
    {
        SceneManager.LoadScene(2);
    }
}
