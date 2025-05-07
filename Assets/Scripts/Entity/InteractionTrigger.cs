using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InteractionTrigger : MonoBehaviour
{


    private bool isPlayerInTrigger = false;
    public TextMeshProUGUI gameGuideText;
    SceneManager sceneManager;
    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.CompareTag("Player"))
        {

            Debug.Log("��ȣ�ۿ� ������ ������ �����߽��ϴ�");
            gameGuideText.gameObject.SetActive(true);
            isPlayerInTrigger=true;
           
            
        }

        

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gameGuideText.gameObject.SetActive(false);
            isPlayerInTrigger=false;
        }
    }


    private void Update()
    {
        if(isPlayerInTrigger && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("RunningMiniGame");
        }

    }

}
