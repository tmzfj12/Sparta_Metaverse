using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 7f;
    public Vector2 minPos = new Vector2(-5.2f, -1.77f);
    public Vector2 maxPos = new Vector2(5.0f, 4.52f);

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

        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minPos.x, maxPos.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minPos.y, maxPos.y);

        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);

    }

}
