using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour {

    public GameObject spawner;
    Rigidbody2D rb;
    float speed = 500f;
    Vector3 localForward;
    float rotationSpeed = 5f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        localForward = spawner.transform.worldToLocalMatrix.MultiplyVector(transform.right);
        rb.AddForce(localForward * speed);
	}

    private void Update()
    {
        transform.Rotate(Vector3.forward * -rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
