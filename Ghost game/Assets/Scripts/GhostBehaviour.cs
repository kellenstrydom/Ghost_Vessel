using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehaviour : MonoBehaviour
{
    private Transform ghost;
    [SerializeField] private Transform vessel;
    [SerializeField] private float speed;
    private Tether _tether;
    [SerializeField] private Hammer selectedHammer;

    private void Start()
    {
        ghost = transform;
        _tether = ghost.GetComponent<Tether>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
        CheckTether();

        if (selectedHammer)
            SelectObject();
    }

    void Move()
    {
        Vector2 moveDir = Vector2.zero;
        moveDir += Vector2.up * Input.GetAxis("Vertical");
        moveDir += Vector2.right * Input.GetAxis("Horizontal");
        
        ghost.Translate(moveDir * (speed* Time.deltaTime));
    }

    void CheckTether()
    {
        if (Vector2.Distance(ghost.position, vessel.position) > _tether.leashRadius)
        {
            ghost.position = vessel.position + ((ghost.position - vessel.position).normalized * _tether.leashRadius);
        }
    }

    void SelectObject()
    {
        if (Input.GetKeyDown(KeyCode.E))
            selectedHammer.Grab(ghost);
        
        if (Input.GetKeyUp(KeyCode.E))
            selectedHammer.Release(ghost);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (selectedHammer) return;
        
        selectedHammer = col.GetComponent<Hammer>();
        
        selectedHammer.HighLight();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Hammer>() == selectedHammer)
        {
            selectedHammer.HighLight(false);
            selectedHammer.Release(ghost);
            selectedHammer = null;
        };
        
    }
}
