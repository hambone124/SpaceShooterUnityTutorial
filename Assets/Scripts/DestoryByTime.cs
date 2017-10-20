using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByTime : MonoBehaviour {

    private void Start()
    {
        DestroyObject(gameObject, 2.0f);
    }
}
