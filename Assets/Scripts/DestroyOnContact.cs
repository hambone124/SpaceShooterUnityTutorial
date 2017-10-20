﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Boundary")
        {
            Debug.Log(other);
            if (other.tag == "Player")
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            }
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}