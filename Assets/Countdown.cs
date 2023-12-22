using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI countDownText; // Reference to the TextMeshProUGUI that shows the count down
    public float timeLeft;
    private int min; //minutes
    private int sec; //seconeds

    void Update()
    {
        UpdateCountdown(); //calling the update count down methoed
    }

    public void UpdateCountdown()
    {
        if (timeLeft > 0) //Check how much time is left 
        {
            timeLeft -= Time.deltaTime; // Decrease the remaining time 

            // Calculate the minutes and seconds from the remaining time
            min = Mathf.FloorToInt(timeLeft / 60);
            sec = Mathf.FloorToInt(timeLeft % 60);
            
            // Format the minutes and seconds into a string and update the TextMeshProUGUI component
            countDownText.text = string.Format("{0:00}:{1:00}", min, sec);
        }
        else
        { 
            //When the count down changes the text to red
            timeLeft = 0;
            countDownText.color = Color.red;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
