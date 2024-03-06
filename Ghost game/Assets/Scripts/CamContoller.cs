using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CamContoller : MonoBehaviour
{
    public Transform focus;
    public Vector2 followOffset;

    private void Update()
    {
        Vector2 offset = Vector2.zero;
        bool isOutsideRange = false;
        
        if (Math.Abs(focus.position.x - transform.position.x) > followOffset.x)
        {
            
            if (focus.position.x > transform.position.x)
            {
                offset.x = focus.position.x - (transform.position.x + followOffset.x);
            }
            else
            {
                offset.x = (followOffset.x- transform.position.x) + focus.position.x;
            }
            
            isOutsideRange = true;
        }
        
        if (Math.Abs(focus.position.y - transform.position.y) > followOffset.y)
        {
            if (focus.position.y > transform.position.y)
            {
                offset.y = focus.position.y - (transform.position.y + followOffset.y);
            }
            else
            {
                offset.y = (followOffset.y - transform.position.y) + focus.position.y;
            }
    
            isOutsideRange = true;
        }
    
        if (isOutsideRange)
        {
            transform.position += (Vector3)offset;
        }
    
    }
}
