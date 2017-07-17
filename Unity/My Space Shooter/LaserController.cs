using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {

    float speed = 7f;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (this.tag == "PlayerLaser")
        {
            rb.velocity = transform.up * speed;
        }
        else if (this.tag == "EnemyLaser")
        {
            rb.velocity = -transform.up * speed;
        }
    }

    //// Update is called once per frame
    //void Update () {

    //    if (this.tag == "PlayerLaser")
    //    {
    //        this.transform.position += new Vector3(0, speed, 0);
    //    }
    //    else if (this.tag == "EnemyLaser")
    //    {
    //        this.transform.position += new Vector3(0, -speed, 0);
    //    }

    //}


}
