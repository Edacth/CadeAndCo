using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour
{

    public bool pressed = false;
    Material myMaterial;

    // Use this for initialization
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            pressed = true;
            myMaterial.color = Color.green;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            pressed = false;
            myMaterial.color = Color.blue;
        }
    }
}
