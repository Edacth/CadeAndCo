using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour
{

    public bool pressed = false;
    public bool prevButtonState;
    public GameObject player;
    public Color passive, highlight;

    private playerController PlayerController;
    private bool hoverOver = false;
    private Transform child;

    private Material myMaterial;
    private Material childMaterial;

    // Use this for initialization
    void Awake()
    {
        prevButtonState = pressed;
        myMaterial = GetComponent<Renderer>().material;
        PlayerController = player.GetComponent<playerController>();
        child = transform.GetChild(0);
        childMaterial = child.GetComponent<Renderer>().material;
    }

    private void OnEnable()
    {
        PlayerController.RemoteControls += myRemoteControledMethod;
        
    }

    private void OnDisable()
    {
        PlayerController.RemoteControls -= myRemoteControledMethod;

    }
    void myRemoteControledMethod()
    {
        if (PlayerController.getRayHit().transform == transform)
        {
            hoverOver = true;
        }
        else
        {
            hoverOver = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && hoverOver)
        {
            pressed = !pressed;
        }

        if (hoverOver && childMaterial.color != highlight)
        {
            childMaterial.color = highlight;
        }
        else if (!hoverOver && childMaterial.color != passive)
        {
            childMaterial.color = passive;
        }

        if (pressed != prevButtonState)
        {
            if (pressed)
            {
                child.transform.localPosition = new Vector3(0, 0 ,0);
            }
            else
            {
                child.transform.localPosition = new Vector3(0, 4f, 0);
            }
            prevButtonState = pressed;
        }

    }
}
