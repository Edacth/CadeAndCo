using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button2Script : MonoBehaviour {

    public enum states
    {
        inactive,
        inView,
        goingDown,
        comingBack,
        holding
    };

    states state = states.inactive; // should this be in start
    public GameObject gameObject;

    Renderer rend;
    public Color inactiveC;
    public Color inViewC;
    public Color activeC;

    float speed = 5f;
    float elapsedTime = 0f;

    void Start()
    {
        inactiveC = gameObject.GetComponent<Color>();
        inViewC = gameObject.GetComponent<Color>();
        activeC = gameObject.GetComponent<Color>();

        rend = gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>();
        rend.material = rend.materials[0];
    }
	
	// Update is called once per frame
	void Update ()
    {
        // ignore my shitty if statement ok
        if (state == states.inactive)
        {
            rend.material.SetColor("_Color", inactiveC);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                state = states.goingDown;
            }

            if (state == states.inView)
            {
                rend.material.SetColor("_Color", inViewC);
            }
            else
            {
                rend.material.SetColor("_Color", activeC);
            }
        }

        if(state == states.goingDown)
        {
            elapsedTime += Time.deltaTime * speed / 100;
            // move button in

        }

	}

    public void PlayerLooking(bool didHit)
    {
        if (didHit) { state = states.inView; }
        else{ state = states.inactive; }
    }
}
