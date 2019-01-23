using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public float moveSpeed;
    public float rotationSpeed;
    
    private Vector2 mouseMovement;
    private static CharacterController controller;
    private Transform cam;
    private float rotationLock = 280f;

    private int interactionLength = 10; // how close you have to be to push buttons
    Ray ray;
    RaycastHit hit;
    public bool isHoldingKey = false;

    // Use this for initialization
    void Start ()
    {
        controller = GetComponent<CharacterController>();
        cam = transform.GetChild(0);
        Cursor.visible = false;
        ray = new Ray(controller.center, controller.transform.forward);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // This changes the player rotation
        // Left/Right
        mouseMovement = new Vector2(Input.GetAxisRaw("Mouse X"), -Input.GetAxisRaw("Mouse Y"));
        Vector3 deltaRotation = new Vector3(0 , mouseMovement.x, 0) * rotationSpeed;
        gameObject.transform.Rotate(deltaRotation);

        // Up/Down
        deltaRotation = new Vector3(mouseMovement.y, 0, 0) * rotationSpeed;
        //float deltaRot = cam.transform.localRotation.x + mouseMovement.y * rotationSpeed;
        
        //if (cam.transform.localRotation.x < 0)
        {
            float diff = rotationLock - cam.transform.localRotation.eulerAngles.x;
            if (cam.transform.localRotation.eulerAngles.x  < rotationLock && cam.transform.localRotation.eulerAngles.x  < 90)
            {
                //deltaRotation = new Vector3(diff, 0, 0);
                Debug.Log("true");
            }
            //print("DeltaRot: " + deltaRot);
            
            // print("Difference: " + diff);

            if (Input.GetKeyDown(KeyCode.E))
            {
                deltaRotation = new Vector3(diff, 0, 0);
            }
        }

        // print("LocalRotation: " + cam.transform.localRotation.eulerAngles);

        /*if (deltaRot < -rotationLock)
        {
            float diff = rotationLock - cam.transform.rotation.x;
            rotation = new Vector3(diff, 0, 0);
        }*/


        cam.transform.Rotate(deltaRotation);
              
        // This handles player movement
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));      
        controller.Move(gameObject.transform.forward * movement.z * moveSpeed);
        controller.Move(gameObject.transform.right * movement.x * moveSpeed );

        // update ray
        // what is the better way to do this?
        ray = new Ray(cam.position, cam.transform.forward);
        // Debug.DrawRay(controller.center, controller.transform.forward, Color.red, 100);

        if (Input.GetKeyDown(KeyCode.I))
        {
            CheckForInteractable();
        }
       
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            isHoldingKey = true;
        }
    }

    void CheckForInteractable()
    {
    
        if (Physics.Raycast(ray, out hit))
        {
            bool didHit = false;
            if (hit.collider.gameObject.tag.Equals("button2"))
            {
                didHit = true;
            }
            hit.collider.gameObject.GetComponent<button2Script>().PlayerLooking(didHit);
        }
  
    }

}
