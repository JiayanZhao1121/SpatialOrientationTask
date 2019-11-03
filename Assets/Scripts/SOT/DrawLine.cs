using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {
    private LineRenderer lineRender;
    private float counter;
    private float dist;
    public Color c1 = Color.black;
    public Color c2 = Color.black;
    public Transform origin;
    public Transform circlePivot;
    private float a;
    private float b;
    private float c;
    private float d;
    private float e;
    private float f;
    private float deltaX;
    private float deltaY;
    private float adjustedEndX;
    private float adjustedEndY;
    private float adjustedDist;
    public float Angle;
    private Vector3 fixedEndPosition;
    public bool isFixed;
    public bool isReadyToContinue;
    

    public float lineDrawSpeed;
    public Transform ButtonTopLeftPivot;
    public Transform ButtonBottomRightPivot;
    RaycastHit hit;
    // Use this for initialization
    void Start()
    {
        lineRender = GetComponent<LineRenderer>();
        lineRender.startColor = Color.black;
        lineRender.endColor = Color.black;
        Angle = 0f;
        fixedEndPosition = new Vector3();
        isReadyToContinue = false;
        isFixed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((!(Camera.main.ScreenToWorldPoint(Input.mousePosition).x > ButtonTopLeftPivot.position.x &&
            Camera.main.ScreenToWorldPoint(Input.mousePosition).x < ButtonBottomRightPivot.position.x &&
             Camera.main.ScreenToWorldPoint(Input.mousePosition).y < ButtonTopLeftPivot.position.y &&
              Camera.main.ScreenToWorldPoint(Input.mousePosition).y > ButtonBottomRightPivot.position.y)) && isFixed == false)
        {


            Vector3 screenPoint = Input.mousePosition;
            screenPoint.z = 0f;
            Vector3 endPosition = new Vector3(Camera.main.ScreenToWorldPoint(screenPoint).x, Camera.main.ScreenToWorldPoint(screenPoint).y,
                0f);
            Vector3 startpoint = new Vector3(origin.position.x, origin.position.y, 0f);
            dist = Vector3.Distance(startpoint, endPosition);
            Vector3 circlePivotAdjustedPosition = new Vector3(circlePivot.position.x, circlePivot.position.y,
                0f);

            //
            a = Vector3.Distance(startpoint, circlePivotAdjustedPosition);
            //Debug.Log("a=" + a);
            b = dist;
            // Debug.Log("dist=" + b);
            c = startpoint.x;
            //Debug.Log("c=" + c);
            d = startpoint.y;
            //Debug.Log("d=" + d);
            e = endPosition.x;
            //Debug.Log("e=" + e);
            f = endPosition.y;
            //Debug.Log("f=" + f);
            deltaX = Mathf.Abs(((e - c) * a) / b);
            deltaY = Mathf.Abs(((f - d) * a) / b);
            // 1st quad
            if (e >= c && f >= d)
            {
                adjustedEndX = c + deltaX;
                adjustedEndY = d + deltaY;
                float cosValue = deltaX / a;
                float TAngle = (Mathf.Acos(cosValue) * 180f) / Mathf.PI;
                Angle = 90f - TAngle;
                Debug.Log("Angle = " + Angle);
            }
            // 4th quad
            else if (e > c && f < d)
            {
                adjustedEndX = c + deltaX;
                adjustedEndY = d - deltaY;
                float cosValue = deltaX / a;
                float TAngle = (Mathf.Acos(cosValue) * 180f) / Mathf.PI;
                Angle = 90f + TAngle;              
            }
            // 2nd quad
            else if (e < c && f > d)
            {
                adjustedEndX = c - deltaX;
                adjustedEndY = d + deltaY;
                float cosValue = deltaX / a;
                float TAngle = (Mathf.Acos(cosValue) * 180f) / Mathf.PI;
                Angle = 270f + TAngle;
            }
            // 3rd quad
            else if (e < c && f < d)
            {
                adjustedEndX = c - deltaX;
                adjustedEndY = d - deltaY;
                float cosValue = deltaX / a;
                float TAngle = (Mathf.Acos(cosValue) * 180f) / Mathf.PI;
                Angle = 270f - TAngle;
            }

            //

            lineRender.startColor = c1;
            lineRender.endColor = c2;

            if (isFixed == false)
            {
                lineRender.SetPosition(0, startpoint);
                counter += 0.1f / lineDrawSpeed;
                adjustedDist = a;
                float x = Mathf.Lerp(0, adjustedDist, counter);
                Vector3 pointA = startpoint;
                Vector3 adjustedEndPosition = new Vector3(adjustedEndX, adjustedEndY, 0f);
                Vector3 pointB = adjustedEndPosition;

                Vector3 pointAlongLine = x * Vector3.Normalize(pointB - pointA) + pointA;
                lineRender.SetPosition(1, pointAlongLine);
            }

        
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Angle = " + Angle);
                isFixed = true;
                float x = Mathf.Lerp(0, adjustedDist, counter);
                Vector3 pointA = startpoint;
                fixedEndPosition = new Vector3(adjustedEndX, adjustedEndY, 0f);
                Vector3 pointB = fixedEndPosition;

                Vector3 pointAlongLine = x * Vector3.Normalize(pointB - pointA) + pointA;
                lineRender.SetPosition(1, pointAlongLine);
                isReadyToContinue = true;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            
            isFixed = false;
       
        }
       
    }
}
