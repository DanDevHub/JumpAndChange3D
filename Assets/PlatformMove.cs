using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    private Vector3 pos1;
    private Vector3 pos2;
    private Vector3 nexPos;

    public Transform childTransform;
    public Transform transformB;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        pos1 = childTransform.localPosition;
        pos2 = transformB.localPosition;
        nexPos = pos2;
    }

    private void FixedUpdate()
    {
        Move();

    }
    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nexPos, speed * Time.deltaTime);
        if(Vector3.Distance(childTransform.localPosition,nexPos) <= 0.1)
        {
            ChangeDestination();
        }
    }

    private void ChangeDestination()
    {
        nexPos = nexPos != pos1 ? pos1:pos2;
    }
}
