//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MoveFormation : MonoBehaviour {

//    float speed = 2f;
//    bool goRight;

//    public GameObject leftBounds;
//    public GameObject rightBounds;
//    GameObject leftMostEnemy;
//    GameObject rightMostEnemy;

//    float screenWidthRight = 8.25f;
//    float screenWidthLeft = -8.25f;


//    GameObject[] enemies;

//    // Use this for initialization
//    void Start () {
//        enemies = GameObject.FindGameObjectsWithTag("Enemy");
//        goRight = PickDirection();
//        //leftMostEnemy = GetLeftMostEnemy();
//        //rightMostEnemy = GetRightMostEnemy();
//	}
	
//	// Update is called once per frame
//	void Update () {

//        //if(leftMostEnemy == null)
//        //{
//        //    leftMostEnemy = GetLeftMostEnemy();
//        //}

//        //if (rightMostEnemy == null)
//        //{
//        //    rightMostEnemy = GetRightMostEnemy();
//        //}

//        if (GetDistanceBetweenRight(rightMostEnemy.transform, rightBounds.transform) <= -6 || GetDistanceBetweenLeft(leftMostEnemy.transform, leftBounds.transform) < 6)
//        {
//            FlipDirection();
//        }
//        if (goRight)
//        {
//            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
//        }
//        else
//        {
//            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
//        }
//	}

//    //gets the opposite direction of the current direction
//    void FlipDirection()
//    {
//        goRight = !goRight;
//    }

//    //picks a random direction, either left or right
//    bool PickDirection()
//    {
//        float random = Random.value;

//        if(random > 0.5f)
//        {
//            return true;
//        }
//        else
//        {
//            return false;
//        }
//    }

//    //gets the enemy farthest to the left on the screen
//    //public GameObject GetLeftMostEnemy()
//    //{
//    //    GameObject leftMost;
//    //    foreach(GameObject enemy in enemies)
//    //    {
//    //        if (enemy.transform.position.x < screenWidthLeft)
//    //        {
//    //            leftMost = enemy;
//    //        }
//    //    }

//    //    return leftMost;
//    //}

//    ////gets the enemy farthest to the right on the screen
//    //public GameObject GetRightMostEnemy()
//    //{
//    //    GameObject rightMost;

//    //    foreach (GameObject enemy in enemies)
//    //    {
//    //        if (enemy.transform.position.x > screenWidthRight)
//    //        {
//    //            rightMost = enemy;
//    //        }
//    //    }

//    //    return rightMost;
//    //}

//    float GetDistanceBetweenLeft(Transform enemy, Transform edge)
//    {
//        return enemy.position.x - edge.position.x - 1;
//    }

//    float GetDistanceBetweenRight(Transform enemy, Transform edge)
//    {
//        return edge.position.x - enemy.position.x - 1;
//    }

//}

