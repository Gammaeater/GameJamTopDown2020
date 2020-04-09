using UnityEngine;
using UnityEngine.UI;




public class TimerCountDown : MonoBehaviour
{


    [SerializeField] private float timeRemaining = 15f;
    [SerializeField] private bool timerIsRunning = false;
    [SerializeField] private Text timeText;
    [SerializeField] private GameObject ToWinTimer;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
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
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                timeText.gameObject.SetActive(false);
                //UIManager.UpdateTimeUI(0f);
                ToWinTimer.SetActive(true);



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
}

