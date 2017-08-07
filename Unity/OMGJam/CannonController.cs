using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonController : MonoBehaviour {

    public GameObject cannonBall;
    public Text cannonBallsText;
    //public GameObject arcPoint;
    public AudioClip CannonFire;

    GameObject[] trajectoryPoints = new GameObject[30];
    Transform spawner;
    float rotationSpeed = 75;
    float rotationAmount = 0;
    int numOfTrajectoryPoints = 30;
    

    bool isRotating = false;
    bool canFire = true;


    private void Start()
    {
        spawner = gameObject.transform.GetChild(0);
        print(spawner.position.x + " " + spawner.position.y);

        //for(int i = 0; i < numOfTrajectoryPoints; i++)
        //{
        //    trajectoryPoints[i] = Instantiate(arcPoint);
        //    trajectoryPoints[i].GetComponent<Renderer>().enabled = false;

        //}
    }

    private void Update()
    {
        if (IsAbleToFire())
        {
            Fire();
        }
    }

    private void OnMouseDrag()
    {
        //rotationAmount += Input.GetAxis("Mouse Y");
        //Debug.Log(rotationAmount);

        float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed;
        transform.Rotate(Vector3.forward, -rotationY * Time.deltaTime);

        float minRotation = 5;
        float maxRotation = 82;
        Vector3 currentRotation = transform.localRotation.eulerAngles;
        currentRotation.z = Mathf.Clamp(currentRotation.z, minRotation, maxRotation);
        transform.localRotation = Quaternion.Euler(currentRotation);

        ////Work here http://www.theappguruz.com/blog/display-projectile-trajectory-path-in-unity
        //setTrajectoryPoints(transform.GetChild(0).transform.position, cannonBall.GetComponent<CannonBall>().localForward);
        //float angle = Mathf.Atan2(vel.y, vel.x) * Mathf.Rad2Deg;
        //transform.eulerAngles = new Vector3(0, 0, angle);
        //setTrajectoryPoints(transform.position, vel / ball.rigidbody.mass);
    }

    private void OnMouseDown()
    {
        isRotating = true;
    }

    private void OnMouseUp()
    {
        isRotating = false;
    }

    private bool IsAbleToFire()
    {
        if (isRotating == false && Input.GetMouseButtonDown(0) && canFire == true && Rounds.Instance.isInWaitRound == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Fire()
    {
        AudioSource.PlayClipAtPoint(CannonFire, Vector3.zero);
        GameObject ball = Instantiate(cannonBall, spawner);
        ball.transform.parent = FindObjectOfType<CannonBallHolder>().transform;
        Rounds.Instance.cannonBallsInStock--;
        Rounds.Instance.cannonBallsLeftAtEndOfRound = Rounds.Instance.cannonBallsInStock;
        cannonBallsText.text = Rounds.Instance.cannonBallsInStock.ToString();

        if (Rounds.Instance.cannonBallsInStock <= 0)
        {
            canFire = false;
        }
    }

    //void setTrajectoryPoints(Vector3 pStartPosition, Vector3 pVelocity)
    //{
    //    float velocity = Mathf.Sqrt((pVelocity.x * pVelocity.x) + (pVelocity.y * pVelocity.y));
    //    float angle = Mathf.Rad2Deg * (Mathf.Atan2(pVelocity.y, pVelocity.x));
    //    float fTime = 0;

    //    fTime += 0.1f;
    //    for (int i = 0; i < numOfTrajectoryPoints; i++)
    //    {

    //        float dx = velocity * fTime * Mathf.Cos(angle * Mathf.Deg2Rad);
    //        float dy = velocity * fTime * Mathf.Sin(angle * Mathf.Deg2Rad) - (Physics2D.gravity.magnitude * fTime * fTime / 2.0f);
    //        Vector3 pos = new Vector3(pStartPosition.x + dx, pStartPosition.y + dy, 2);
    //        trajectoryPoints[i].transform.position = pos;
    //        trajectoryPoints[i].GetComponent<Renderer>().enabled = true;
    //        trajectoryPoints[i].transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(pVelocity.y - (Physics.gravity.magnitude) * fTime, pVelocity.x) * Mathf.Rad2Deg);
    //        fTime += 0.1f;
    //    }
    //}
}
