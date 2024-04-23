using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWithTouch : MonoBehaviour
{
    [SerializeField] private GameObject linePrefab;
    [SerializeField] private float minDistance = 0.1f;
    [SerializeField, Range(0f, 2f)] private float defaultWidth = 0.1f;
    [SerializeField, Range(0f, 2f)] private float midWidth = 0.15f;
    [SerializeField, Range(0f, 2f)] private float boldWidth = 0.5f;

    private List<Vector3> currentLinePoints;
    private GameObject currentLineObject;
    private LineRenderer currentLineRenderer;
    StampManager stampManager;
    private bool isDusterMode = false;
    private bool isMidWidth = false;
    private bool isBoldWidth = false;
    private bool isThinWidth = false;
    public bool isDraw = true;
    private Color currentColor;
    [SerializeField] GameObject colorPicker;

    private void Start()
    {
        currentLinePoints = new List<Vector3>();
        stampManager = GetComponent<StampManager>();
    }

    public void Draw()
    {
        if (isDraw)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                CreateNewLine();
            }
            else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector3 touchPosition = GetTouchWorldPosition(Input.GetTouch(0));
                if (currentLinePoints.Count == 0 || Vector3.Distance(touchPosition, currentLinePoints[currentLinePoints.Count - 1]) > minDistance)
                {
                    AddPointToCurrentLine(touchPosition);
                }
            }
        }
    }

    private void Update()
    {
        Draw();
    }

    private void CreateNewLine()
    {
        if (true)
        {

            currentLineObject = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);            
            currentLineObject.tag = "Line(Clone)";
            currentLineRenderer = currentLineObject.GetComponent<LineRenderer>();
            currentLineRenderer.startColor = currentColor;
            currentLineRenderer.endColor = currentColor;
            if (isMidWidth)
            {
                currentLineRenderer.startColor = currentColor;
                currentLineRenderer.endColor = currentColor;
                currentLineRenderer.startWidth = currentLineRenderer.endWidth = midWidth;
            }
            if (isBoldWidth)
            {
                currentLineRenderer.startColor = currentColor;
                currentLineRenderer.endColor = currentColor;
                currentLineRenderer.startWidth = currentLineRenderer.endWidth = boldWidth;
            }
            if (isThinWidth)
            {
                currentLineRenderer.startColor = currentColor;
                currentLineRenderer.endColor = currentColor;
                currentLineRenderer.startWidth = currentLineRenderer.endWidth = defaultWidth;
            }

            if (isDusterMode)
            {
                currentLineRenderer.startColor = Color.white;
                currentLineRenderer.endColor = Color.white;
                
            }
            currentLinePoints.Clear();
        }

    }

    public void SetColor(Color color)
    {
        if(currentLineRenderer == null)
        {
            return;
        }
        currentColor = color;
    }

    private void AddPointToCurrentLine(Vector3 point)
    {
        currentLinePoints.Add(point);

        currentLineRenderer.positionCount = currentLinePoints.Count;
        currentLineRenderer.SetPositions(currentLinePoints.ToArray());
    }

    private Vector3 GetTouchWorldPosition(Touch touch)
    {
        Vector3 touchPosition = touch.position;
        touchPosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(touchPosition);
    }
    public void ClearLines()
    {
        GameObject[] lineClones = GameObject.FindGameObjectsWithTag("Line(Clone)");

        foreach (GameObject clone in lineClones)
        {
            if (clone.CompareTag("Line(Clone)"))
            {
                Destroy(clone);
            }
        }

        currentLinePoints.Clear();
    }

    public void ColorPicker()
    {
        if (colorPicker != null)
        {
            colorPicker.SetActive(true);
        }

    }

    public void DusterMode()
    {
        isDusterMode = true;
        isDraw = true;
        stampManager.isCirclePrefab = false;
        stampManager.isTrianglePrefab = false;
        stampManager.isSquarePrefab = false;
    }

    public void MidWidth()
    {
        isDusterMode = false;
        isDraw = true;
        isMidWidth = true;
        isThinWidth = false;
        isBoldWidth = false;
        stampManager.isCirclePrefab = false;
        stampManager.isTrianglePrefab = false;
        stampManager.isSquarePrefab = false;
    }

    public void BoldWidth()
    {
        isDusterMode = false;
        isDraw = true;
        isBoldWidth = true;
        isMidWidth = false;
        isThinWidth = false;
        stampManager.isCirclePrefab = false;
        stampManager.isTrianglePrefab = false;
        stampManager.isSquarePrefab = false;
    }

    public void ThinWidth()
    {
        isDusterMode = false;
        isDraw = true;
        isThinWidth = true;
        isMidWidth = false;
        isBoldWidth = false;
        stampManager.isCirclePrefab = false;
        stampManager.isTrianglePrefab = false;
        stampManager.isSquarePrefab = false;
    }
















    //private void Start()
    //{
    //    currentLinePoints = new List<Vector3>();
    //    stampManager = GetComponent<StampManager>();
    //}

    //public void Draw()
    //{
    //    if (isDraw)
    //    {
    //        if (Input.GetMouseButtonDown(0))
    //        {
    //            CreateNewLine();
    //        }
    //        else if (Input.GetMouseButton(0))
    //        {
    //            Vector3 mousePosition = GetMouseWorldPosition();
    //            if (currentLinePoints.Count == 0 || Vector3.Distance(mousePosition, currentLinePoints[currentLinePoints.Count - 1]) > minDistance)
    //            {
    //                AddPointToCurrentLine(mousePosition);
    //            }
    //        } 
    //    }

    //}
    //private void Update()
    //{
    //    Draw();
    //}

    //private void CreateNewLine()
    //{
    //    if (isDraw)
    //    {
    //        currentLineObject = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
    //        currentLineObject.tag = "Line(Clone)";
    //        currentLineRenderer = currentLineObject.GetComponent<LineRenderer>();

    //        if (isMidWidth)
    //        {
    //            currentLineRenderer.startWidth = currentLineRenderer.endWidth = midWidth;
    //        }
    //        if (isBoldWidth)
    //        {
    //            currentLineRenderer.startWidth = currentLineRenderer.endWidth = boldWidth;
    //        }
    //        if (isThinWidth)
    //        {
    //            currentLineRenderer.startWidth = currentLineRenderer.endWidth = defaultWidth;
    //        }

    //        if (isDusterMode)
    //        {
    //            currentLineRenderer.startColor = Color.white;
    //            currentLineRenderer.endColor = Color.white;
    //        }

    //        currentLinePoints.Clear();
    //    }

    //}

    //private void AddPointToCurrentLine(Vector3 point)
    //{
    //    currentLinePoints.Add(point);

    //    currentLineRenderer.positionCount = currentLinePoints.Count;
    //    currentLineRenderer.SetPositions(currentLinePoints.ToArray());
    //}

    //private Vector3 GetMouseWorldPosition()
    //{
    //    Vector3 mousePosition = Input.mousePosition;
    //    mousePosition.z = -Camera.main.transform.position.z;
    //    return Camera.main.ScreenToWorldPoint(mousePosition);
    //}
    //public void ClearLines()
    //{
    //    GameObject[] lineClones = GameObject.FindGameObjectsWithTag("Line(Clone)");

    //    foreach (GameObject clone in lineClones)
    //    {
    //        if (clone.CompareTag("Line(Clone)"))
    //        {
    //            Destroy(clone);
    //        }
    //    }

    //    currentLinePoints.Clear();
    //}

    //public void DusterMode()
    //{
    //    isDusterMode = true;
    //    isDraw = true;
    //    stampManager.isCirclePrefab = false;
    //    stampManager.isTrianglePrefab = false;
    //    stampManager.isSquarePrefab = false;
    //}

    //public void MidWidth()
    //{
    //    isMidWidth = true;
    //    isThinWidth = false;
    //    isBoldWidth = false;
    //    stampManager.isCirclePrefab = false;
    //    stampManager.isTrianglePrefab = false;
    //    stampManager.isSquarePrefab = false;
    //}

    //public void BoldWidth()
    //{
    //    isBoldWidth = true;
    //    isMidWidth = false;
    //    isThinWidth = false;
    //    stampManager.isCirclePrefab = false;
    //    stampManager.isTrianglePrefab = false;
    //    stampManager.isSquarePrefab = false;
    //}

    //public void ThinWidth()
    //{
    //    isThinWidth = true;
    //    isMidWidth = false;
    //    isBoldWidth = false;
    //    stampManager.isCirclePrefab = false;
    //    stampManager.isTrianglePrefab = false;
    //    stampManager.isSquarePrefab = false;
    //}
}
