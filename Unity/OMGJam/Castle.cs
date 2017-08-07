using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Castle : MonoBehaviour {

    public AudioClip explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Castle hit!");
        if (collision.gameObject.GetComponent<Ship>())
        {
            //wait until the explosion happens
            SceneManager.LoadScene(2);
        }
    }

}
