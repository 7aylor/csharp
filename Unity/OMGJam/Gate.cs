using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {

    public AudioClip explosion;
    public GameObject explosionObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //play gate explosion sound
        //AudioSource.PlayClipAtPoint(explosion, Vector3.zero);

        //destroy gate
        //Destroy(gameObject);

        

        ////get the enemy ship
        //Ship enemyShip = collision.gameObject.GetComponent<Ship>();

        ////if there is a ship, destroy it
        //if (enemyShip != null)
        //{
        //    Debug.Log("Ship Destroyed");
        //    enemyShip.DestroyShip();
        //}
    }
}
