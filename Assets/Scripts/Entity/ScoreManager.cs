using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI gameGuideText;
    
    // Start is called before the first frame update
    void Start()
    {
        gameGuideText.gameObject.SetActive(false);

        int score = PlayerPrefs.GetInt("LastGameScore", 0);
       scoreText.text = score.ToString();

        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        highScoreText.text = highScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
