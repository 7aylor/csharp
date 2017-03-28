﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Nucleon : MonoBehaviour {

    public float attractionForce;        

    Rigidbody body;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        body.AddForce(transform.localPosition * -attractionForce);
    }

}
