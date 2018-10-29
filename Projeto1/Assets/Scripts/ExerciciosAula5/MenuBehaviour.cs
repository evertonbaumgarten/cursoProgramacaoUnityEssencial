using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuBehaviour : MonoBehaviour {
    const string LEVEL_IZY = "IZY";
    const string LEVEL_NORMAL = "NORMAL";
    const string LEVEL_HARD = "HARD";

    public Button StartButton;
    public Button LevelButton;
    public Button CreditButton;
    public Button CreditCloseButton;

    public GameObject LevelPanel;
    public GameObject CreditPanel;

    public GameObject LevelIzy;
    public GameObject LevelNormal;
    public GameObject LevelHard;


    string currentLevel = LEVEL_IZY;

    private void Start()
    {
        LevelButton.GetComponentInChildren<Text>().text = currentLevel;
        LevelPanel.SetActive(false);
    }

    public void onStartButtonClick()
    {
        SceneManager.LoadScene("Scenes/ExerciciosAula5/Level"+ currentLevel, LoadSceneMode.Single);
    }

    public void onLevelButtonClick()
    {
        LevelPanel.SetActive(true);
    }

    public void onCreditButtonClick()
    {
        CreditPanel.SetActive(true);
    }

    public void onCreditCloseButtonClick()
    {
        CreditPanel.SetActive(false);
    }

    public void onLevelChooseButtonClick(string option)
    {
        LevelPanel.SetActive(false);
        currentLevel = option;
        LevelButton.GetComponentInChildren<Text>().text = currentLevel;
    }
}
