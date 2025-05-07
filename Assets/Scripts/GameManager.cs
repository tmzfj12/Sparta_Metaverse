using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    
    public static GameManager Instance { get { return gameManager; } }

    private int currentScore = 0;

    UIManager uiManager;

    public UIManager UIManager { get { return uiManager; } }

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();

    }


    private void Start()
    {

        uiManager.UpdateScore(0);
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
        uiManager.SetContinue();

        PlayerPrefs.SetInt("LastGameScore", currentScore);
        PlayerPrefs.Save();


        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score :" + currentScore);
        uiManager.UpdateScore(currentScore);
    }

}


public class GameEndHandler : MonoBehaviour
{
    public int score;

    public void EndGame()
    {
       

    }

        
}