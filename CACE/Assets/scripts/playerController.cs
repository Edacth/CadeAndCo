using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public float moveSpeed;
    public float rotationSpeed;
    public bool isHoldingKey = false;

    private Vector2 mouseMovement;
    private Transform rotationProbe;
    private static CharacterController controller;
    private Transform cam;
    private float rotationLock = 280f;

    private int interactionLength = 10; // how close you have to be to push buttons
    Ray ray;
    RaycastHit hit;

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

        rotationProbe.Rotate(deltaRotation);
        //float deltaRot = cam.transform.localRotation.x + mouseMovement.y * rotationSpeed;
        
        if (rotationProbe.localRotation.y == 180) 
        {
            /*float diff = rotationLock - cam.transform.localRotation.eulerAngles.x;
            if (cam.transform.eulerAngles.x < rotationLock && cam.transform.eulerAngles.x  < 90)
            {
                
                Debug.Log("true");
            }*/
           

            /*if (Input.GetKeyDown(KeyCode.E))
            {
                deltaRotation = new Vector3(diff, 0, 0);
            }*/

            //rotationProbe.eulerAngles
        }

        print("LocalRotation: " + cam.transform.eulerAngles);


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
