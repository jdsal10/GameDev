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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            if (timeLeft < 0)
            {
                timeLeft = 0;
                countDownText.color = Color.red;
                SceneManager.LoadSceneAsync(0);
            }
        }

        timeLeft -= Time.deltaTime;
        min = Mathf.FloorToInt(timeLeft / 60);
        sec = Mathf.FloorToInt(timeLeft % 60);
        countDownText.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}
