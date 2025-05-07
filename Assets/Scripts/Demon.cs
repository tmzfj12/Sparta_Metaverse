using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : MonoBehaviour
{
    
    GameManager gameManager;
    public Transform demonObject;

    public float widthPadding = 15f;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int demonCount)
    {
        Vector3 placePosition = lastPosition + new Vector3(widthPadding,0);
        placePosition.y = -3f;
      

        transform.position = placePosition;

        return placePosition;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

       if(collision.CompareTag("Player"))
        {
            gameManager.AddScore(1);
        }

    }


}
