using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]

public class Ghost : ScriptableObject
{
    public bool isRecord;
    public bool isReplay;
    public bool bestTime;
    public bool driving;
    public float recordFrquancy;

    public List<float> timeStamp;
    public List<Vector3> position;
    public List<Vector3> rotation;

    public List<float> timeStampBest;
    public List<Vector3> positionBest;
    public List<Vector3> rotationBest;

    private void Awake()
    {
        DontDestroyOnLoad(this);
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
