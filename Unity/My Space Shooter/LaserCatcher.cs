using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCatcher : MonoBehaviour {

    //destroy any object that enters our collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DestroyLasers(collision.gameObject);
    }

    public static void DestroyLasers(GameObject lasers)
    {
        //get the parent of the colliding object (this is the empty game object that holds the lasers)
        Transform parent = lasers.gameObject.transform.parent;

        //If there is a parents
        if (parent != null)
        {
            //loop through the children of the parent and delete them
            foreach (Transform child in lasers.transform.parent)
            {
                Destroy(child.gameObject);
            }

            //delete parent
            Destroy(parent.gameObject);
        }
        else
        {
            Destroy(lasers);
        }
    }

}
