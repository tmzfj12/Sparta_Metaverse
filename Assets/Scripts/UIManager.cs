using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;









public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI continueText;

    private void Start()
    {
       continueText.gameObject.SetActive(false);



    }

    public void SetContinue()
    {
        continueText.gameObject.SetActive(true);
    }


    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

}
