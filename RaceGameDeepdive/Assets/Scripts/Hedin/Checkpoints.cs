using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoints : MonoBehaviour
{

    [Header("checkpoints")]
    public GameObject start;
    public GameObject end;
    public GameObject[] checkpoints;

    [Header("Settings")]
    public float laps = 1;

    [Header("Information")]
    private float currentCheckpoint;
    private float currentLap;
    private bool started;
    private bool finished;

    public GameObject ghostcar;
    

    private static float currentLapTime;
    public static float bestLapTime;
    public static float bestLap;

    public Ghost ghost;
    private void Start()
    {
        ghostcar.SetActive(false);

        currentCheckpoint = 0;
        currentLap = 1;

        started = false;
        finished = false;

        currentLapTime = 0;
        bestLapTime = 0;

    }

    private void Update()
    {
        if (started && !finished)
        {
            currentLapTime += Time.deltaTime;

            if (bestLap == 0)
            {
                bestLap = 1;
            }
        }

        if (bestLap == currentLap)
        {
            bestLapTime = currentLapTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            GameObject thischeckpoint = other.gameObject;

            //started the race//
            if (thischeckpoint == start && !started)
            {
                print("started");
                ghost.ResetData();
                ghost.driving = true;
                ghost.isRecord = true;
                ghostcar.SetActive (true);
                started = true;
                if (ghost.bestTime == true)
                {
                    ghost.isReplay = true;
                }
            }
            // ended the lap//
            else if (thischeckpoint == end && started)
            {
                //if all laps are finished, end the race//
                if (currentLap == laps)
                {
                    if (currentCheckpoint == checkpoints.Length)
                    {
                        Debug.Log("Last checkpoint");
                        ghost.isRecord = false;
                        ghost.isReplay = false;

                        ghost.positionBest = new List<Vector3>(ghost.position);
                        ghost.rotationBest = new List<Vector3>(ghost.rotation);
                        ghost.timeStampBest = new List<float>(ghost.timeStamp);
                        ghost.bestTime = true;

                        if (currentLapTime < bestLapTime)
                        {
                            Debug.Log("Best time");
                            bestLap = currentLap;
                            ghost.positionBest = new List<Vector3>(ghost.position);
                            ghost.rotationBest = new List<Vector3>(ghost.rotation);
                            ghost.timeStampBest = new List<float>(ghost.timeStamp);
                            ghost.bestTime = true;
                        }

                        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
                        finished = true;
                        print("Finished");
                    }
                    else
                    {
                        print("Did not go through all checkpoints");

                    }

                }
                // if all laps are not finished, start a new lap//
                else if (currentLap < laps)
                {
                    if (currentCheckpoint == checkpoints.Length)
                    {
                        if (currentLapTime < bestLapTime)
                        {
                            bestLap = currentLap;
                            bestLapTime = currentLapTime;
                        }

                        currentLap++;
                        currentCheckpoint = 0;
                        currentLapTime = 0;
                        print($"Started lap {currentLap} - {Mathf.FloorToInt(currentLapTime / 60)}:{currentLapTime % 60:00.000}");
                    }
                }
                else
                {
                    print("Did not go trhough all checkpoints");
                }
            }
            //Loop through the checkpoints and compare and check wchich one player past trough//
            for (int i = 0; i < checkpoints.Length; i++)
            {
                if (finished)
                    return;

                // If the checkpoint is correct//
                if (thischeckpoint == checkpoints[i] && i == currentCheckpoint)
                {
                    print($"correct checkpoint - {Mathf.FloorToInt(currentLapTime / 60)}:{currentLapTime % 60:00.000}");
                    currentCheckpoint++;
                }
                else if (thischeckpoint == checkpoints[i] && i != currentCheckpoint)
                {
                    print("incorrect checkpoint");
                }
            }
        }
    }
    private void OnGUI()
    {
        //GUI Style//
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 40;
        myStyle.normal.textColor = Color.white;
        myStyle.fontStyle = FontStyle.BoldAndItalic;
        //current time//
        string formattedCurrentTime = $"Current: {Mathf.FloorToInt(currentLapTime / 60)}:{currentLapTime % 60:00.000} - (Lap {currentLap})";
        GUI.Label(new Rect(10, 20, 250, 100), formattedCurrentTime, myStyle);
        // best time //
        string formattedBestTime = $"best: {Mathf.FloorToInt(bestLapTime / 60)}:{bestLapTime % 60:00.000} - (Lap {bestLap})";
        GUI.Label(new Rect(550, 20, 250, 100), formattedBestTime, myStyle);
    }
}