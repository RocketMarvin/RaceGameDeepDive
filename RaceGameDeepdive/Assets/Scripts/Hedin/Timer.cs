using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timeText;
    public Text lapText;
    public GameObject lapTextShow;
    static float timer;
    public int min, sec, milli;
    void Start()
    {
        lapTextShow.SetActive(false);
    }

    void Update()
    {
        timer += Time.deltaTime;

        min = Mathf.FloorToInt(timer / 60);
        sec = Mathf.FloorToInt(timer - min * 60);
        milli = Mathf.FloorToInt(timer * 1000f) % 1000;
        string time = string.Format("Time: {0:0}:{1:00}:{2:000}", min, sec, milli);

        timeText.text = time;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LastLap"))
        {
            lapTextShow.SetActive(true);
            string time = string.Format("Time: {0:0}:{1:00}:{2:000}", min, sec, milli);
            lapText.text = time;
        }
        
    }
}
