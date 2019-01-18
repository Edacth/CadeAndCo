using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public float moveSpeed;
    public float rotationSpeed;
    
    private Vector2 mouseMovement;
    private CharacterController controller;
    private Transform cam;
    private float rotationLock = 0.7f;

    bool isHoldingKey = false;

    // Use this for initialization
    void Start ()
    {
        controller = GetComponent<CharacterController>();
        cam = transform.GetChild(0);
        Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        // This changes the player rotation
        mouseMovement = new Vector2(Input.GetAxisRaw("Mouse X"), -Input.GetAxisRaw("Mouse Y"));
        Vector3 rotation = new Vector3(0 , mouseMovement.x, 0);
        gameObject.transform.Rotate(rotation * rotationSpeed);

        rotation = new Vector3(mouseMovement.y, 0, 0);
        float deltaRot = cam.transform.rotation.x + mouseMovement.y * rotationSpeed;
        if (deltaRot > rotationLock)
        {
            float diff = rotationLock - cam.transform.rotation.x;
            rotation = new Vector3(diff, 0, 0);

        }
        /*if (deltaRot < -rotationLock)
        {
            float diff = rotationLock - cam.transform.rotation.x;
            rotation = new Vector3(diff, 0, 0);
        }*/
        cam.transform.Rotate(rotation * rotationSpeed);
        
        Debug.Log(cam.transform.localRotation);
        // This handles player movement
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));      
        controller.Move(gameObject.transform.forward * movement.z * moveSpeed);
        controller.Move(gameObject.transform.right * movement.x * moveSpeed );
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            isHoldingKey = true;
        }
    }

}
