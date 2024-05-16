using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class Ghost : ScriptableObject
{
    public bool isRecord;
    public bool isReplay;
    public bool bestTime = false;
    public float recordFrquancy;

    public List<float> timeStamp;
    public List<Vector3> position;
    public List<Vector3> rotation;

    public List<float> timeStampBest;
    public List<Vector3> positionBest;
    public List<Vector3> rotationBest;

    private void Start()
    {
        isRecord = false;
        if (bestTime = false)
        {
            isReplay = false;
        }
        ResetData();
}
    public void ResetDataBest()
    {
        timeStampBest.Clear();
        positionBest.Clear();
        rotationBest.Clear();
    }
    public void ResetData()
    {
        timeStamp.Clear();
        position.Clear();
        rotation.Clear();
    }
}
