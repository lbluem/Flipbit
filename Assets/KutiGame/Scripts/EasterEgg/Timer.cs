using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Timer : MonoBehaviour
{

    private float timeRemaining = 0f;
    private bool timeIsRunning = false;
    public TMP_Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        // Event prerequisites
        Player_Movement player_Movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>();
        player_Movement.OnGravityChange += ChangeTurned;       
    }

    // Timer starts at the very first swap in Lvl 1
    private void ChangeTurned(bool turnedFromPlayer)
    {
       timeIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeIsRunning)
        {
            if(timeRemaining >= 0)
            {
                timeRemaining += Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            // If the end Level is reached the Timer stops
            if(SceneManager.GetActiveScene().buildIndex == 10)
            {
                timeIsRunning = false;
            }
        }
    }
    void DisplayTime (float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay/60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = Mathf.FloorToInt((timeToDisplay % 1)*100);
        timeText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes,seconds,milliseconds);
    }
}
