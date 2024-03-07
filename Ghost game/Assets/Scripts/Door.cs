using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Transform ghost;
    public bool isGrabbed;
    private float restPos;
    public float displaceDistance;
    public float ghostOffset;

    public Transform test;

    // Start is called before the first frame update
    void Start()
    {
        restPos = transform.position.y;
        //Grab(test);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrabbed)
        {
            if (ghost.position.y - ghostOffset < restPos) return;
            if (ghost.position.y - ghostOffset > restPos + displaceDistance)
                transform.position = new Vector3(transform.position.x, restPos + displaceDistance);
            else
            {
                transform.position = new Vector3(transform.position.x, ghost.position.y - ghostOffset);
            }
        }
    }

    public void Grab(Transform ghost)
    {
        if (isGrabbed)
        {
            isGrabbed = false;
            this.ghost = null;
        }
        else
        {
            isGrabbed = true;
            this.ghost = ghost;
            ghostOffset = ghost.position.y - restPos;
        }
    }
    
    public void HighLight(bool isOn = true)
    {
        gameObject.GetComponent<Outline>().enabled = isOn;
        Debug.Log("highlight");
    }
}
