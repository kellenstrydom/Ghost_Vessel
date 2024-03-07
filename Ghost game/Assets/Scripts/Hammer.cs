using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public HingeJoint2D hinge;
    private Transform ghost;
    public bool isGrabbed;
    
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (isGrabbed)
        {
            SetAngle();
            hinge.useLimits = true;
        }
        else
        {
            hinge.useLimits = false;
        }
    }

    void SetAngle()
    {
        //Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Vector2.Angle(new Vector2(0,-1), ((Vector2)ghost.position-hinge.connectedAnchor).normalized);
        if (angle > 120) angle = 120;
        if (ghost.position.x > hinge.connectedAnchor.x) angle *= -1;
        JointAngleLimits2D jl = new JointAngleLimits2D();
        jl.min = angle;
        jl.max = angle;
        hinge.limits = jl;
    }

    public void HighLight(bool isOn = true)
    {
        gameObject.GetComponent<Outline>().enabled = isOn;
        Debug.Log("highlight");
    }

    public void Grab(Transform ghost)
    {
        if (isGrabbed)
        {
            Release(ghost);
            return;
        }
        
        this.ghost = ghost;
        isGrabbed = true;
    }

    public void Release(Transform ghost)
    {
        if (this.ghost == ghost) ghost = null;
        isGrabbed = false;
    }
}
