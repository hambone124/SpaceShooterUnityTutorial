using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    private Rigidbody rg;
    public float speed = 5.0f;

    private void Start()
    {
        rg = GetComponent<Rigidbody>();
        rg.velocity = transform.forward * speed;
    }
}
