using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tether : MonoBehaviour
{
    public LineRenderer line;
    public Transform ghost;
    public Transform vessel;
    public float leashRadius;

    // Update is called once per frame
    void LateUpdate()
    {
        line.SetPosition(0,vessel.position);
        line.SetPosition(1,ghost.position);
    }
}
