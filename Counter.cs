using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
    private float timeRemaining = 60;
    private bool timerIsRunning = false;
    public Text timeText;
    public Levelmanager gameover;
    Gaze gaze;
    Ghost g;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        gaze = FindObjectOfType<Gaze>();
        g = FindObjectOfType<Ghost>();
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                //Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                GameOver();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void GameOver()
    {
        int xp = gaze.GetXp();
        gaze.SetFlag();
        g.CancelingInvoke();
        g.stopMove();
        gameover.Setup(xp);
    }
}
