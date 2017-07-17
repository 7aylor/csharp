using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFormation : MonoBehaviour {

    float speed = 2f;
    bool goRight;

    const float xMin = -1;
    const float xMax = 1;

    // Use this for initialization
    void Start () {
        goRight = PickDirection();
    }
	
	// Update is called once per frame
	void Update () {

        if(transform.position.x <= xMin || transform.position.x >= xMax)
        {
            goRight = !goRight;
        }

        if (goRight)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }

    //picks a random direction, either left or right
    bool PickDirection()
    {
        float random = Random.value;

        if (random > 0.5f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
