using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CheckpointsAndLaps : MonoBehaviour
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


    private void Start()
    {
        currentCheckpoint = 0;
        currentLap = 1;

        started = false;
        finished = false;
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
                started = true;
            }

            // ended the lap//
            else if (thischeckpoint == end && started)
            {
                //if all laps are finished, end the race//
                if (currentLap == laps)
                {
                    if (currentCheckpoint == checkpoints.Length)
                    {
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
                        currentLap++;
                        currentCheckpoint = 0;
                        print($"Started lap {currentLap}");
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
                    print("correct checkpoint");
                    currentCheckpoint++;
                }
                else if (thischeckpoint == checkpoints[i] && i != currentCheckpoint)
                {
                    print("incorrect checkpoint");
                }
            }
        }
    }
}
