using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRecorder : MonoBehaviour
{
    public Ghost ghost;
    private float Timer;
    private float timeValue;

    private void Awake()
    {
        ghost.driving = false;
        if (ghost.isRecord)
        {
            ghost.ResetData();
            timeValue = 0;
            Timer = 0;
        }
    }
    private void Update()
    {
        if (ghost.driving == true)
        {
            Timer += Time.unscaledDeltaTime;
            timeValue += Time.unscaledDeltaTime;

            if (ghost.isRecord & Timer >= 1 / ghost.recordFrquancy)
            {
                ghost.timeStamp.Add(timeValue);
                ghost.position.Add(this.transform.position);
                ghost.rotation.Add(this.transform.eulerAngles);

                Timer = 0;
            }
        }
    }
}
