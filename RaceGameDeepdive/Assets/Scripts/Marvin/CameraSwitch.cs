using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject camera1, camera2, camera3;

    public int camManager = 0;
    private bool camToggle = false;

    private void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            camToggle = !camToggle;
            Debug.Log("input c");
            camManager++;
            Debug.Log(camManager);
        }
        if (camManager >= 3) camManager = 0;
    }

    public void Cam_1()
    {
        camera1.SetActive(true);
        camera2.SetActive(false);
        camera3.SetActive(false);
    }
    public void Cam_2()
    {
        camera1.SetActive(false);
        camera2.SetActive(true);
        camera3.SetActive(false);
    }
    public void Cam_3()
    {
        camera1.SetActive(false);
        camera2.SetActive(false);
        camera3.SetActive(true);
    }

    public void ManageCamera()
    {
        if (camToggle)
        {
            Cam_2();
            camManager = 1;
        }
        else
        {
            Cam_1();
           camManager = 0;
        }

        
    }

}
