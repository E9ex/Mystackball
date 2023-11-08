using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class stackPartController : MonoBehaviour
{
    private Rigidbody rb;
    private MeshRenderer _meshRenderer;
    private StackController _stackController;
    private Collider _collider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _stackController = transform.parent.GetComponent<StackController>();
        _collider = GetComponent<Collider>();
    }

    public void shatter()
    {
        rb.isKinematic = false;
        _collider.enabled = false;

        Vector3 forcepoint = transform.parent.position;
        float paretxPos = transform.parent.position.x;
        float xpos = _meshRenderer.bounds.center.x;

        Vector3 subdir = (paretxPos - xpos < 0) ? Vector3.right : Vector3.left;
        Vector3 dir = (Vector3.up * 1.5f + subdir).normalized;
        
        float force = Random.Range(20, 35);
        float tork = Random.Range(110, 180);
        
        rb.AddForceAtPosition(dir*force, forcepoint,ForceMode.Impulse);
        rb.AddTorque(Vector3.left*tork);
        rb.velocity = Vector3.down;
    }

    public void removeAllChilds()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).SetParent(null);
            i--;
        }
    }

}
