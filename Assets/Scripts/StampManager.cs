using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampManager : MonoBehaviour
{
    DrawWithTouch drawWithTouch;
    public GameObject circlePrefab;
    public GameObject trianglePrefab;
    public GameObject squarePrefab;

    public bool isCirclePrefab = false;
    public bool isTrianglePrefab = false;
    public bool isSquarePrefab = false;

    private void Start()
    {
        drawWithTouch = GetComponent<DrawWithTouch>();
    }

    private void Update()
    {
        if (isCirclePrefab)
        {
            CircleStamp();
        }
        if (isTrianglePrefab)
        {
            TriangleStamp();
        }
        if (isSquarePrefab)
        {
            SquareStamp();
        }
    }

    public void CircleStamp()
    {
        isCirclePrefab = true;
        isTrianglePrefab = false;
        isSquarePrefab = false;
        drawWithTouch.isDraw = false;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 touchPosition = GetTouchWorldPosition(Input.GetTouch(0));
            GameObject circle = Instantiate(circlePrefab, touchPosition, Quaternion.identity);
            circle.tag = "Line(Clone)";
        }
    }

    public void TriangleStamp()
    {
        isCirclePrefab = false;
        isTrianglePrefab = true;
        isSquarePrefab = false;
        drawWithTouch.isDraw = false;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 touchPosition = GetTouchWorldPosition(Input.GetTouch(0));
            GameObject triangle = Instantiate(trianglePrefab, touchPosition, Quaternion.identity);
            triangle.tag = "Line(Clone)";
        }
    }

    public void SquareStamp()
    {
        isCirclePrefab = false;
        isTrianglePrefab = false;
        isSquarePrefab = true;
        drawWithTouch.isDraw = false;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 touchPosition = GetTouchWorldPosition(Input.GetTouch(0));
            GameObject square = Instantiate(squarePrefab, touchPosition, Quaternion.identity);
            square.tag = "Line(Clone)";
        }
    }

    Vector3 GetTouchWorldPosition(Touch touch)
    {
        Vector3 touchPosition = touch.position;
        touchPosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(touchPosition);
    }
}
