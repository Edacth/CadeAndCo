using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public float moveSpeed;
    public float rotationSpeed;
    public bool isHoldingKey = false;

    public int maxHealth = 3;
    public int health;

    private Vector2 mouseMovement;
    private static CharacterController controller;
    private Transform cam;
    private float rotationLock = 280f;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = transform.GetChild(0);
        Cursor.visible = false;

        health = maxHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // This changes the player rotation
        // Left/Right
        mouseMovement = new Vector2(Input.GetAxisRaw("Mouse X"), -Input.GetAxisRaw("Mouse Y"));
        Vector3 deltaRotation = new Vector3(0, mouseMovement.x, 0) * rotationSpeed;
        gameObject.transform.Rotate(deltaRotation);

        // Up/Down
        deltaRotation = new Vector3(mouseMovement.y, 0, 0) * rotationSpeed;

        print("LocalRotation: " + cam.transform.eulerAngles);


        cam.transform.Rotate(deltaRotation);

        // This handles player movement
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(gameObject.transform.forward * movement.z * moveSpeed);
        Debug.Log(gameObject.transform.forward * movement.z * moveSpeed);
        controller.Move(gameObject.transform.right * movement.x * moveSpeed);

        if(health <= 0)
        {
            // return to origin
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            isHoldingKey = true;
        }

        if (other.gameObject.CompareTag("hazard"))
        {

        }
    }

}