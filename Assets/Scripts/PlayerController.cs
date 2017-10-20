using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    public float speed;
    public float tilt;
    private Rigidbody rg;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;

    private float nextFire = 0.0f;
    public float fireRate = 0.5f;

    private void Update()
    {
        if (Input.GetButton("Fire1") && (Time.time > nextFire))
        {
            nextFire = Time.time + fireRate;
            Instantiate<GameObject>(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }       
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rg = GetComponent<Rigidbody>();
        rg.velocity = movement * speed;
        rg.position = new Vector3
            (
                Mathf.Clamp (rg.position.x,boundary.xMin,boundary.xMax),
                0.0f,
                Mathf.Clamp(rg.position.z, boundary.zMin, boundary.zMax)
            );
        rg.rotation = Quaternion.Euler(0.0f, 0.0f, rg.velocity.x * -tilt);
    }
}
