using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.NetworkInformation;
using UnityEngine;

public class GhostPlayer : MonoBehaviour
{
    private bool bestTime = false;
    public Ghost ghost;
    private float timeValue;
    private int index1;
    private int index2;

    private void Awake()
    {
        timeValue = 0;
        ghost.isRecord = false;
        if (bestTime == false)
        {
            ghost.isReplay = false;
        }
        ghost.ResetData();
    }

    private void Update()
    {
        timeValue += Time.unscaledDeltaTime;

        if (ghost.isReplay)
        {
            GetIndex();
            SetTransform();
        }
        
    }

    private void GetIndex()
    {
        for (int i = 0; i < ghost.timeStampBest.Count -2; i++)
        {
            if (ghost.timeStampBest[i] == timeValue)
            {
                index1 = i;
                index2 = i + 1;
                return;
            }
            else if (ghost.timeStampBest[i] < timeValue & timeValue < ghost.timeStampBest[i + 1])
            {
                index1 = i;
                index2 = i + 1;
                return;
            }
        }

        index1 = ghost.timeStampBest.Count - 1;
        index2 = ghost.timeStampBest.Count - 1;
    }
    private void SetTransform()
    {
        if (index1 == index2)
        {
            this.transform.position = ghost.positionBest[index1];
            this.transform.eulerAngles = ghost.rotationBest[index1];
        }
        else
        {
            float interpolationfactor = (timeValue - ghost.timeStampBest[index1] / (ghost.timeStampBest[index2] - ghost.timeStampBest[index1]));

            this.transform.position = Vector3.Lerp(ghost.positionBest[index1], ghost.positionBest[index2], interpolationfactor);
            this.transform.eulerAngles = Vector3.Lerp(ghost.rotationBest[index1], ghost.rotationBest[index2], interpolationfactor);
        }
    }
}
