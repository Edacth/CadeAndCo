using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

    public Camera thisCam;
    int rotationSpeed = 1;
    float prevMousePos;
    float rot = 0;
    // y angle of fov / 2
    public int fovY = 70;

    // Use this for initialization
    void Start()
    {
        thisCam = GetComponent<Camera>();
        prevMousePos = Input.mousePosition.y;
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        float mousePos = Input.mousePosition.y;
        Vector3 net = new Vector3(rotationSpeed, 0, 0);
        if(prevMousePos - mousePos > 0 && rot < fovY)
        {
            thisCam.transform.Rotate(-net);
            rot += rotationSpeed;
        }
        if (prevMousePos - mousePos < 0 && rot > -fovY)
        {
            thisCam.transform.Rotate(net);
            rot -= rotationSpeed;
        }
        prevMousePos = mousePos;

        Debug.Log(rot);
	}
}
