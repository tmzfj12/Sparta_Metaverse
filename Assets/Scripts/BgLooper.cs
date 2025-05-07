using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 8;
    public int demonCount = 0;
    public Vector3 demonLastPosition = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        Demon[] demons = GameObject.FindObjectsOfType<Demon>();
        demonLastPosition = demons[0].transform.position;
        demonCount = demons.Length;
        float firstX = 11f;
        demonLastPosition = new Vector3(firstX, -3);

        for (int i = 0; i < demonCount; i++)
        {
            demonLastPosition = demons[i].SetRandomPlace(demonLastPosition, demonCount);
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Ground"))
        {
            float widhOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;
            
            pos.x += widhOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }



        Demon demon = collision.GetComponent<Demon>();
        if (demon)
        {
            demonLastPosition = demon.SetRandomPlace(demonLastPosition, demonCount);
        }

    }
}