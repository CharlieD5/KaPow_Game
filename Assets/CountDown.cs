using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public Text countDown = null;
    public Text scoreText = null;
    float currentTime = 1f;
    float StartingTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = StartingTime;
        Color c = scoreText.color;
        c.a = 0.0f;
    }

    // Update is called once per frameS
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countDown.text = currentTime.ToString("0");

        if (currentTime < 1)
        {
            countDown.text = "GO!";
        }

        if (currentTime < 0)
        {
            countDown.text = null;
            Color c = scoreText.color;
            c.a = 1f;
        }
    }
}
