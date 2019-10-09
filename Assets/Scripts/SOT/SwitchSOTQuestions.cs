using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SwitchSOTQuestions : MonoBehaviour {
    public GameObject SP;
    public GameObject EQ;
    public GameObject Q1;
    public GameObject Q2;
    public GameObject Q3;
    public GameObject Q4;
    public GameObject Q5;
    public GameObject Q6;
    public GameObject Q7;
    public GameObject Q8;
    public GameObject Q9;
    public GameObject Q10;
    public GameObject Q11;
    public GameObject Q12;

    public GameObject LineDraw;
    public float timeLimit = 420f;
    // public GameObject enterParticipantNameGameobject;
    public Text ParticipantNameText;
    private int pointingAngle;

    public Text TimerText;
    private float startTime;
    private int countForTimer;
    private void Start()
    {
        startTime = 0f;
        countForTimer = 0;
    }
    private void Update()
    {
        
        if (SP.activeSelf || EQ.activeSelf)
        {
            LineDraw.SetActive(false);
        }
        else
        {
            LineDraw.SetActive(true);
        }

        if (Q1.activeSelf && countForTimer == 0)
        {
            startTime = Time.time;
            countForTimer++;
        }
        if (countForTimer != 0)
        {
            float remainTime = timeLimit + 0.99f - Time.time + startTime;
            int min = (int)(remainTime / 60f);
            int seconds = (int)remainTime - (min * 60);
            if (seconds < 10)
            {
            TimerText.text = min.ToString() + " : " + "0" + seconds.ToString();
            }
            else
            {
                TimerText.text = min.ToString() + " : " + seconds.ToString();
            }
            if (min == 0 && seconds < 1)
            {
               // UnityEditor.EditorApplication.isPlaying = false;
                Application.Quit();
            }

        }
    }
    public void SPToEQ()
    {
        
        if (ParticipantNameText.text != "")
        {
 SP.SetActive(false);
        EQ.SetActive(true);
        LineDraw.GetComponent<DrawLine>().isFixed = false;
        }
       
        
        
    }
    public void EQToQ1()
    {
        EQ.SetActive(false);
        Q1.SetActive(true);
        LineDraw.GetComponent<DrawLine>().isFixed = false;
    }
    public void Q1ToQ2()
    {
        if (LineDraw.GetComponent<DrawLine>().isFixed == true)
        {
            pointingAngle = (int)LineDraw.GetComponent<DrawLine>().Angle; // valid input
            Debug.Log("pointing angle = " + pointingAngle);
            Q1.SetActive(false);
            Q2.SetActive(true);
            getTheData(123, 1);
            LineDraw.GetComponent<DrawLine>().isFixed = false;
        }
        
    }
    public void Q2ToQ3()
    {
        if (LineDraw.GetComponent<DrawLine>().isFixed == true)
        {
            pointingAngle = (int)LineDraw.GetComponent<DrawLine>().Angle; // valid input
            Debug.Log("pointing angle = " + pointingAngle);
            Q2.SetActive(false);
            Q3.SetActive(true);
            getTheData(237, 2);
            LineDraw.GetComponent<DrawLine>().isFixed = false;
        }
    }
    public void Q3ToQ4()
    {
        if (LineDraw.GetComponent<DrawLine>().isFixed == true)
        {
            pointingAngle = (int)LineDraw.GetComponent<DrawLine>().Angle; // valid input
            Q3.SetActive(false);
            Q4.SetActive(true);
            getTheData(83, 3);
            LineDraw.GetComponent<DrawLine>().isFixed = false;
        }
    }
    public void Q4ToQ5()
    {
        if (LineDraw.GetComponent<DrawLine>().isFixed == true)
        {
            pointingAngle = (int)LineDraw.GetComponent<DrawLine>().Angle; // valid input
            Q4.SetActive(false);
            Q5.SetActive(true);
            getTheData(156, 4);
            LineDraw.GetComponent<DrawLine>().isFixed = false;
        }
    }
    public void Q5ToQ6()
    {
        if (LineDraw.GetComponent<DrawLine>().isFixed == true)
        {
            pointingAngle = (int)LineDraw.GetComponent<DrawLine>().Angle; // valid input
            Q5.SetActive(false);
            Q6.SetActive(true);
            getTheData(319, 5);
            LineDraw.GetComponent<DrawLine>().isFixed = false;
        }
    }
    public void Q6ToQ7()
    {
        if (LineDraw.GetComponent<DrawLine>().isFixed == true)
        {
            pointingAngle = (int)LineDraw.GetComponent<DrawLine>().Angle; // valid input
            Q6.SetActive(false);
            Q7.SetActive(true);
            getTheData(235, 6);
            LineDraw.GetComponent<DrawLine>().isFixed = false;
        }
    }
    public void Q7ToQ8()
    {
        if (LineDraw.GetComponent<DrawLine>().isFixed == true)
        {
            pointingAngle = (int)LineDraw.GetComponent<DrawLine>().Angle; // valid input
            Q7.SetActive(false);
            Q8.SetActive(true);
            getTheData(333, 7);
            LineDraw.GetComponent<DrawLine>().isFixed = false;
        }
    }
    public void Q8ToQ9()
    {
        if (LineDraw.GetComponent<DrawLine>().isFixed == true)
        {
            pointingAngle = (int)LineDraw.GetComponent<DrawLine>().Angle; // valid input
            Q8.SetActive(false);
            Q9.SetActive(true);
            getTheData(260, 8);
            LineDraw.GetComponent<DrawLine>().isFixed = false;
        }
    }
    public void Q9ToQ10()
    {
        if (LineDraw.GetComponent<DrawLine>().isFixed == true)
        {
            pointingAngle = (int)LineDraw.GetComponent<DrawLine>().Angle; // valid input
            Q9.SetActive(false);
            Q10.SetActive(true);
            getTheData(280, 9);
            LineDraw.GetComponent<DrawLine>().isFixed = false;
        }
    }
    public void Q10ToQ11()
    {
        if (LineDraw.GetComponent<DrawLine>().isFixed == true)
        {
            pointingAngle = (int)LineDraw.GetComponent<DrawLine>().Angle; // valid input
            Q10.SetActive(false);
            Q11.SetActive(true);
            getTheData(48, 10);
            LineDraw.GetComponent<DrawLine>().isFixed = false;
        }
    }
    public void Q11ToQ12()
    {
        if (LineDraw.GetComponent<DrawLine>().isFixed == true)
        {
            pointingAngle = (int)LineDraw.GetComponent<DrawLine>().Angle; // valid input
            Q11.SetActive(false);
            Q12.SetActive(true);
            getTheData(26, 11);
            LineDraw.GetComponent<DrawLine>().isFixed = false;
        }
    }
    public void Q12ToEnd()
    {
        if (LineDraw.GetComponent<DrawLine>().isFixed == true)
        {
            pointingAngle = (int)LineDraw.GetComponent<DrawLine>().Angle; // valid input
            getTheData(150, 12);
           UnityEditor.EditorApplication.isPlaying = false;
           // Application.Quit();
        }
    }

    public void Reset()
    {
        LineDraw.GetComponent<DrawLine>().isFixed = false;
    }
    void getTheData(float correctAngle, int questionNumber)
    {
        string filePath = @"Assets/Resource/SOT_saved_data.csv";
        //string filePath =  Application.dataPath + "/ExperimentData/SOT_saved_data.csv"; 
        File.AppendAllText(filePath, ParticipantNameText.text
            + "," + questionNumber.ToString() + "," +
            pointingAngle.ToString() + "," + ((int)correctAngle).ToString() + ","
          + (Mathf.Abs((int)LineDraw.GetComponent<DrawLine>().Angle - (int)correctAngle)).ToString() + "\n");
    }
}
