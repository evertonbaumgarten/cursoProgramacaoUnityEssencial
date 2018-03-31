using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanelBehaviour : MonoBehaviour {

    public GameObject scoreItemCellPrefab;
    public Transform scoreDetailedPanel;
    public Text scoreTotalText;


    private void Start()
    {
        scoreTotalText.text = GalagaGameManager.instance.getTotalScore().ToString();
        int lineCounter = 0;
        foreach (var item in GalagaGameManager.instance.getScoreTable())
        {
            //Cria uma instancia do prefab que possui os elementos de cada linha do Score
            GameObject scoreLine = Instantiate<GameObject>(scoreItemCellPrefab);
            //Coloca o objeto como filho do painel de score
            scoreLine.transform.parent = scoreDetailedPanel;
            //Devido a escala do Canvas, precisamos forçar para que a escala do elemento fique em 1
            scoreLine.transform.localScale = Vector3.one;
            //Ajusta a posição dele na tela levando em conta a quantidade de linhas
            scoreLine.transform.localPosition = Vector2.down * lineCounter++ * 80;

            Debug.Log("item.Key" + item.Key);
            //Configura o sprite correto segundo o valor que está no dicinário 
            scoreLine.GetComponent<ScoreItemCellPrefabHelperBehaviour>().alienSprite.sprite = Resources.Load<Sprite>("Sprites/"+item.Key);
            scoreLine.GetComponent<ScoreItemCellPrefabHelperBehaviour>().alienCounter.text = item.Value.ToString();
        }
    }
}
