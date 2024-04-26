using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField] GameObject gameLogic;
    private float timeRemaining;
    private bool timeIsRunning = true;
    public TMP_Text timeText;
    public void SetTimeIsRunning(bool timeIsRunning)
    {
        this.timeIsRunning = timeIsRunning;
    }
    public void SetTimeRemaining(float time)
    {
        timeRemaining = time;
    }
    public float GetTimeRemaining()
    {
        return timeRemaining;
    }

    void Start()
    {
        timeRemaining = 5 * 60;
        timeIsRunning = true;
    }

    void Update()
    {
        if (timeIsRunning)
        {
            if (timeRemaining >= 0)
            {
                timeRemaining -= Time.deltaTime; // Subtract Time.deltaTime to make the time run backward
                DisplayTime(timeRemaining);
            }
            else
            {
                gameLogic.GetComponent<GameLogic>().LostTheGame();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
