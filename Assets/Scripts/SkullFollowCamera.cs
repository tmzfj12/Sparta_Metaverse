using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullFollowCamera : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 10f;
    public Vector2 minPos = new Vector2(-5.2f, -2.27f);
    public Vector2 maxPos = new Vector2(5.0f, 0.2f);

    private Vector3 offset;

    void Start()
    {
        if (target == null)
            return;

        offset = transform.position - target.position;


    }

    // Update is called once per frame
    void Update()
    {


    }

    private void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPosition = target.position + offset;
        desiredPosition.z = transform.position.z;

       
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minPos.y, maxPos.y);

        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);

    }

}
