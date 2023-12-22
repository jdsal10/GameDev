using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI countDownText;
    public float timeLeft;
    private int min;
    private int sec;

    void Update()
    {
        UpdateCountdown();
    }

    public void UpdateCountdown()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;

            min = Mathf.FloorToInt(timeLeft / 60);
            sec = Mathf.FloorToInt(timeLeft % 60);
            countDownText.text = string.Format("{0:00}:{1:00}", min, sec);
        }
        else
        {
            timeLeft = 0;
            countDownText.color = Color.red;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
