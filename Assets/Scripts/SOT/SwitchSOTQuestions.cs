using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SwitchSOTQuestions : MonoBehaviour {
    public GameObject SP;
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

    public GameObject Canvas1;

    public GameObject LineDraw;
    public bool shouldLineDrawActive = false;
    public float timeLimit = 300f;
    // public GameObject enterParticipantNameGameobject;
    public Text ParticipantNameText;
    private int pointingAngle;

    public Text TimerText;
    private float startTime;
    private int countForTimer;
    public GameObject canvas;
    public float delayTime = 1f;
    public int finishedRound = 0;
    public int totalAngularError = 0;
    private string filePath;
    private void Start()
    {
        startTime = 0f;
        countForTimer = 0;
         filePath = @"Assets/Resource/SOT_saved_data.csv";
      //filePath = Application.dataPath + "/ExperimentData/SOT_saved_data.csv";
    }
    private void Update()
    {

        if (!shouldLineDrawActive)
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
       
        if (canvas.activeSelf)
        {

        
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
                  

                    for (int i = finishedRound+1; i < 13; i++)
                    {
                        
                       
                        File.AppendAllText(filePath, ParticipantNameText.text
         + "," + i.ToString() + "," +
        "Null"+ "," + "Null" + ","
       + "Null" + "\n");
                    }
                   
                    File.AppendAllText(filePath, ParticipantNameText.text
      + "," + "Finished round" + "," +
      finishedRound.ToString() + "," + "Average" + ","
    + (totalAngularError/finishedRound).ToString() + "\n");

                   UnityEditor.EditorApplication.isPlaying = false;
               // Application.Quit();
            }

        }
        }
        else
        {
            startTime = startTime + Time.deltaTime;
        }
        
    }
    public void StartPageToExample()
    {
        
        if (ParticipantNameText.text != "")
        {
            canvas.transform.Find("StartPage").gameObject.SetActive(false);
            canvas.transform.Find("Example").gameObject.SetActive(true);
        LineDraw.GetComponent<DrawLine>().isFixed = false;
            shouldLineDrawActive = true;
        }
       
        
        
    }
    public void ExampleToTransition1()
    {
        if (LineDraw.GetComponent<DrawLine>().isFixed == true)
        {
 shouldLineDrawActive = false;
        canvas.transform.Find("Example").gameObject.SetActive(false);
        canvas.transform.Find("Transition1").gameObject.SetActive(true);
        LineDraw.GetComponent<DrawLine>().isFixed = false;
        }
        else
        {
           
            shouldLineDrawActive = false;
            Canvas1.gameObject.SetActive(true);
            canvas.SetActive(false);
        }
           

    }
    public void Transition1ToTraining1()
    {
       
            shouldLineDrawActive = true;
        canvas.transform.Find("Transition1").gameObject.SetActive(false);
        canvas.transform.Find("Training1").gameObject.SetActive(true);
        LineDraw.GetComponent<DrawLine>().isFixed = false;

    }
    public void showTraining1CorrectAnswer()
    {
        if (LineDraw.GetComponent<DrawLine>().isFixed == true)
        {
            canvas.transform.Find("Training1").Find("correctAnswer").gameObject.SetActive(true);
        canvas.transform.Find("Training1").Find("Reset").gameObject.SetActive(false);
        canvas.transform.Find("Training1").Find("Continue").gameObject.SetActive(false);
        Invoke("Training1ToTraining2", delayTime);
        }
        else
        {

            shouldLineDrawActive = false;
            Canvas1.gameObject.SetActive(true);
            canvas.SetActive(false);
        }
    }
    private void Training1ToTraining2()
    {
        LineDraw.GetComponent<DrawLine>().isFixed = false;
        canvas.transform.Find("Training1").gameObject.SetActive(false);
        canvas.transform.Find("Training2").gameObject.SetActive(true);
    }
    public void showTraining2CorrectAnswer()
    {
        if (LineDraw.GetComponent<DrawLine>().isFixed == true)
        {
            canvas.transform.Find("Training2").Find("correctAnswer").gameObject.SetActive(true);
        canvas.transform.Find("Training2").Find("Reset").gameObject.SetActive(false);
        canvas.transform.Find("Training2").Find("Continue").gameObject.SetActive(false);
        Invoke("Training2ToTraining3", delayTime);
        }
        else
        {

            shouldLineDrawActive = false;
            Canvas1.gameObject.SetActive(true);
            canvas.SetActive(false);
        }
    }
    private void Training2ToTraining3()
    {
        LineDraw.GetComponent<DrawLine>().isFixed = false;
        canvas.transform.Find("Training2").gameObject.SetActive(false);
        canvas.transform.Find("Training3").gameObject.SetActive(true);
    }
    public void showTraining3CorrectAnswer()
    {
        if (LineDraw.GetComponent<DrawLine>().isFixed == true)
        {
            canvas.transform.Find("Training3").Find("correctAnswer").gameObject.SetActive(true);
        canvas.transform.Find("Training3").Find("Reset").gameObject.SetActive(false);
        canvas.transform.Find("Training3").Find("Continue").gameObject.SetActive(false);
        Invoke("Training3ToTransition2", delayTime);
        }
        else
        {

            shouldLineDrawActive = false;
            Canvas1.gameObject.SetActive(true);
            canvas.SetActive(false);
        }
    }
    private void Training3ToTransition2()
    {
        LineDraw.GetComponent<DrawLine>().isFixed = false;
        shouldLineDrawActive = false;
        canvas.transform.Find("Training3").gameObject.SetActive(false);
        canvas.transform.Find("Transition2").gameObject.SetActive(true);
    }
    public void Transition2ToQ1()
    {
        shouldLineDrawActive = true;
        canvas.transform.Find("Transition2").gameObject.SetActive(false);
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
            getTheData(143, 1);
         
            LineDraw.GetComponent<DrawLine>().isFixed = false;
        }
        else
        {

            shouldLineDrawActive = false;
            Canvas1.gameObject.SetActive(true);
            canvas.SetActive(false);
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
            getTheData(249, 2);
            LineDraw.GetComponent<DrawLine>().isFixed = false;
        }
        else
        {

            shouldLineDrawActive = false;
            Canvas1.gameObject.SetActive(true);
            canvas.SetActive(false);
        }
    }
    public void Q3ToQ4()
    {
        if (LineDraw.GetComponent<DrawLine>().isFixed == true)
        {
            pointingAngle = (int)LineDraw.GetComponent<DrawLine>().Angle; // valid input
            Q3.SetActive(false);
            Q4.SetActive(true);
            getTheData(93, 3);
            LineDraw.GetComponent<DrawLine>().isFixed = false;
        }
        else
        {

            shouldLineDrawActive = false;
            Canvas1.gameObject.SetActive(true);
            canvas.SetActive(false);
        }
    }
    public void Q4ToQ5()
    {
        if (LineDraw.GetComponent<DrawLine>().isFixed == true)
        {
            pointingAngle = (int)LineDraw.GetComponent<DrawLine>().Angle; // valid input
            Q4.SetActive(false);
            Q5.SetActive(true);
            getTheData(165, 4);
            LineDraw.GetComponent<DrawLine>().isFixed = false;
        }
        else
        {

            shouldLineDrawActive = false;
            Canvas1.gameObject.SetActive(true);
            canvas.SetActive(false);
        }
    }
    public void Q5ToQ6()
    {
        if (LineDraw.GetComponent<DrawLine>().isFixed == true)
        {
            pointingAngle = (int)LineDraw.GetComponent<DrawLine>().Angle; // valid input
            Q5.SetActive(false);
            Q6.SetActive(true);
            getTheData(318, 5);
            LineDraw.GetComponent<DrawLine>().isFixed = false;
        }
        else
        {

            shouldLineDrawActive = false;
            Canvas1.gameObject.SetActive(true);
            canvas.SetActive(false);
        }
    }
    public void Q6ToQ7()
    {
        if (LineDraw.GetComponent<DrawLine>().isFixed == true)
        {
            pointingAngle = (int)LineDraw.GetComponent<DrawLine>().Angle; // valid input
            Q6.SetActive(false);
            Q7.SetActive(true);
            getTheData(250, 6);
            LineDraw.GetComponent<DrawLine>().isFixed = false;
        }
        else
        {

            shouldLineDrawActive = false;
            Canvas1.gameObject.SetActive(true);
            canvas.SetActive(false);
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
        else
        {

            shouldLineDrawActive = false;
            Canvas1.gameObject.SetActive(true);
            canvas.SetActive(false);
        }
    }
    public void Q8ToQ9()
    {
        if (LineDraw.GetComponent<DrawLine>().isFixed == true)
        {
            pointingAngle = (int)LineDraw.GetComponent<DrawLine>().Angle; // valid input
            Q8.SetActive(false);
            Q9.SetActive(true);
            getTheData(268, 8);
            LineDraw.GetComponent<DrawLine>().isFixed = false;
        }
        else
        {

            shouldLineDrawActive = false;
            Canvas1.gameObject.SetActive(true);
            canvas.SetActive(false);
        }
    }
    public void Q9ToQ10()
    {
        if (LineDraw.GetComponent<DrawLine>().isFixed == true)
        {
            pointingAngle = (int)LineDraw.GetComponent<DrawLine>().Angle; // valid input
            Q9.SetActive(false);
            Q10.SetActive(true);
            getTheData(266, 9);
            LineDraw.GetComponent<DrawLine>().isFixed = false;
        }
        else
        {

            shouldLineDrawActive = false;
            Canvas1.gameObject.SetActive(true);
            canvas.SetActive(false);
        }
    }
    public void Q10ToQ11()
    {
        if (LineDraw.GetComponent<DrawLine>().isFixed == true)
        {
            pointingAngle = (int)LineDraw.GetComponent<DrawLine>().Angle; // valid input
            Q10.SetActive(false);
            Q11.SetActive(true);
            getTheData(41, 10);
            LineDraw.GetComponent<DrawLine>().isFixed = false;
        }
        else
        {

            shouldLineDrawActive = false;
            Canvas1.gameObject.SetActive(true);
            canvas.SetActive(false);
        }
    }
    public void Q11ToQ12()
    {
        if (LineDraw.GetComponent<DrawLine>().isFixed == true)
        {
            pointingAngle = (int)LineDraw.GetComponent<DrawLine>().Angle; // valid input
            Q11.SetActive(false);
            Q12.SetActive(true);
            getTheData(25, 11);
            LineDraw.GetComponent<DrawLine>().isFixed = false;
        }
        else
        {

            shouldLineDrawActive = false;
            Canvas1.gameObject.SetActive(true);
            canvas.SetActive(false);
        }
    }
    public void Q12ToEnd()
    {
        if (LineDraw.GetComponent<DrawLine>().isFixed == true)
        {
            pointingAngle = (int)LineDraw.GetComponent<DrawLine>().Angle; // valid input
            getTheData(151, 12);

        
            File.AppendAllText(filePath, ParticipantNameText.text
+ "," + "Finished round" + "," +
finishedRound.ToString() + "," + "Average" + ","
+ (totalAngularError / finishedRound).ToString() + "\n");

            UnityEditor.EditorApplication.isPlaying = false;
           //  Application.Quit();
        }
        else
        {

            shouldLineDrawActive = false;
            Canvas1.gameObject.SetActive(true);
            canvas.SetActive(false);
        }
    }

    public void Reset()
    {
        LineDraw.GetComponent<DrawLine>().isFixed = false;
    }
    void getTheData(float correctAngle, int questionNumber)
    {
        finishedRound++;
     
        float angularError = 0;
        if (Mathf.Abs((int)LineDraw.GetComponent<DrawLine>().Angle - (int)correctAngle) > 180){
            angularError = 360 - Mathf.Abs((int)LineDraw.GetComponent<DrawLine>().Angle - (int)correctAngle);
        }
        else
        {
            angularError = Mathf.Abs((int)LineDraw.GetComponent<DrawLine>().Angle - (int)correctAngle);
        }
        totalAngularError = totalAngularError + (int)angularError;
        File.AppendAllText(filePath, ParticipantNameText.text
            + "," + questionNumber.ToString() + "," +
            pointingAngle.ToString() + "," + ((int)correctAngle).ToString() + ","
          + angularError.ToString() + "\n");
    }
    public void OK()
    {
        canvas.SetActive(true);
        shouldLineDrawActive = true;
        Canvas1.gameObject.SetActive(false);
    }





}
