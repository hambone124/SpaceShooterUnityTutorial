using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    private Rigidbody rg;
    public float speed;

    private void Start()
    {
        rg = GetComponent<Rigidbody>();
        rg.velocity = transform.forward * speed;
    }
}
