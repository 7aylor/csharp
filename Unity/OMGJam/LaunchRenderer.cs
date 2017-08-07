using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class LaunchRenderer : MonoBehaviour
{
    LineRenderer lr;
    float startPos;

    public float velocity = 5f;
    public float angle = 45f;
    public int resolution = 10;

    float g; // force of gravity
    float radianAngle;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        g = Mathf.Abs(Physics.gravity.y);
    }

    void Start()
    {
        startPos = GameObject.FindObjectOfType<CannonController>().transform.GetChild(0).transform.position.y;
        RenderIt();
    }

    private void RenderIt()
    {
        lr.positionCount = resolution + 1;
        lr.SetPositions(CalcArray());
    }

    Vector3[] CalcArray()
    {
        Vector3[] array = new Vector3[resolution + 1];

        radianAngle = Mathf.Deg2Rad * angle;
        float maxDis = (velocity * velocity * Mathf.Sin(2 * radianAngle)) / g;

        for (int i = 0; i <= resolution; i++)
        {
            float t = (float)i / (float)resolution;
            array[i] = CalcPoint(t, maxDis);
        }

        return array;
    }

    Vector3 CalcPoint(float t, float maxDistance)
    {
        float x = t * maxDistance;
        float y = startPos + (x * Mathf.Tan(radianAngle) - ((g * x * x) / (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle))));
        return new Vector3(x, y, -5f);
    }
}