using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playerController : MonoBehaviour
{
    public delegate void delRemoteControl();

    public float moveSpeed;
    public float rotationSpeed;
    public bool isHoldingKey = false;

    //public List<delRemoteControl> RemoteControls = new List<delRemoteControl>();
    public delRemoteControl RemoteControls;
    
    private Vector2 mouseMovement;
    private static CharacterController controller;
    private Transform cam;
    private float rotationLock = 280f;

    private int interactionLength = 10; // how close you have to be to push buttons
    private Ray ray;
    private RaycastHit rayHit;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = transform.GetChild(0);
        Cursor.visible = false;
        

        ray = new Ray(cam.position, cam.transform.forward);
    }

    void FixedUpdate()
    {
        // This changes the player rotation
        // Left/Right
        mouseMovement = new Vector2(Input.GetAxisRaw("Mouse X"), -Input.GetAxisRaw("Mouse Y"));
        Vector3 deltaRotation = new Vector3(0, mouseMovement.x, 0) * rotationSpeed;
        gameObject.transform.Rotate(deltaRotation);

        // Up/Down
        deltaRotation = new Vector3(mouseMovement.y, 0, 0) * rotationSpeed;

        cam.transform.Rotate(deltaRotation);

        // This handles player movement
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(gameObject.transform.forward * movement.z * moveSpeed);

        controller.Move(gameObject.transform.right * movement.x * moveSpeed );

        // Raycasting
        ray = new Ray(cam.position, cam.transform.forward * interactionLength);
        Debug.DrawRay(cam.position, cam.transform.forward * interactionLength, Color.red, 0.01f);
        CheckForInteractable();
        RemoteControls.Invoke();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            isHoldingKey = true;
        }

    }

    void CheckForInteractable()
    {
        LayerMask mask = LayerMask.GetMask("interactable");
        if (Physics.Raycast(ray, out rayHit, interactionLength, mask))
        {
            
            bool didHit = false;
            if (rayHit.collider.gameObject.tag.Equals("button"))
            {                
            }
        }
    }

    public RaycastHit getRayHit()
    {
        return rayHit;
    }

}