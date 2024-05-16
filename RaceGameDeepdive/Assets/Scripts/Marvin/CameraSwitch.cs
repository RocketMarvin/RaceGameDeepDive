using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject camera1, camera2, camera3, camera4;

    public int camManager = 0;
    private bool camToggle = false;

    private void Update()
    {
        if (Input.GetKeyDown("c") || Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            camToggle = !camToggle;
            Debug.Log("input c");
            camManager++;
            Debug.Log(camManager);
            ManageCamera();
        }
        if (camManager >= 4) camManager = 0;
    }

    public void Cam_1()
    {
        camera1.SetActive(true);
        camera2.SetActive(false);
        camera3.SetActive(false);
        camera4.SetActive(false);
    }
    public void Cam_2()
    {
        camera1.SetActive(false);
        camera2.SetActive(true);
        camera3.SetActive(false);
        camera4.SetActive(false);
    }
    public void Cam_3()
    {
        camera1.SetActive(false);
        camera2.SetActive(false);
        camera3.SetActive(true);
        camera4.SetActive(false);
    }
    public void Cam_4()
    {
        camera1.SetActive(false);
        camera2.SetActive(false);
        camera3.SetActive(false);
        camera4.SetActive(true);
    }

    public void ManageCamera()
    {
        switch(camManager)
        {
            case 0: 
                Cam_1();
                Debug.Log("cam1");
                break;
            case 1:
                Cam_2();
                Debug.Log("cam2");
                break;
            case 2:
                Cam_3();
                Debug.Log("cam3");
                break;
            case 3:
                Cam_4();
                Debug.Log("cam4");
                break;
            default:
                Cam_1();
                Debug.Log("cam def");
                break;
        }

        
    }

}
