using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int moveSpeed = 10;
    public int rotationSpeed = 3;
    public Rigidbody rb;
    Vector3 prevMousePos;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        prevMousePos = Input.mousePosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // player rotation
        Vector3 mousePos = Input.mousePosition;
        Vector3 rotation = new Vector3(0, rotationSpeed, 0);
        float dif = mousePos.x - prevMousePos.x;
        if (dif < 0)
        {
            rb.transform.Rotate(rotation * -1);
        }
        if (dif > 0)
        {
            rb.transform.Rotate(rotation);
        }
        prevMousePos = mousePos;
        // move forward back towards the center of screen

        // player movement (WASD)
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));      
        float rotationFromOrig = Vector3.Angle(new Vector3(0, 0, 1), rb.transform.forward);
        if (rb.transform.forward.x < 0)
        {
            rotationFromOrig = 180 - rotationFromOrig + 180;
        }

        Quaternion rotationFromOriginQ = Quaternion.Euler(0, rotationFromOrig, 0);
        Vector3 netMovement = rotationFromOriginQ * movement;

        netMovement.Normalize();
        
        rb.MovePosition(rb.position + netMovement * (moveSpeed / 100f));

        Debug.Log(rb.transform.forward);
    }

}
