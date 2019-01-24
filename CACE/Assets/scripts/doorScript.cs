using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour {

    public bool prevButtonState;
    public GameObject myButton;
    public float lowerBound;
    public float upperBound;

    private buttonScript myButtonScript;
    private IEnumerator coroutine;

    float t = 0;
    float interpos;

    void Start ()
    {
        myButtonScript = myButton.GetComponent<buttonScript>();
        prevButtonState = myButtonScript.pressed;
    }
	
	void Update ()
    {
        if (myButtonScript.pressed != prevButtonState)
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }
            
            coroutine = Open(myButtonScript.pressed ? 1 : 0);
            
            StartCoroutine(coroutine);
            prevButtonState = myButtonScript.pressed;
        }

        /*if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("O");
            coroutine = Open(1);
            
            StartCoroutine(coroutine);
            

        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P");
            coroutine = Open(0);

            StartCoroutine(coroutine);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            StopCoroutine(coroutine);
        }*/

    }

    IEnumerator Open(float goal)
    {
        while (goal >= t)
        {      
            t += 0.01f;

            interpos = (lowerBound * (1 - t) + upperBound * t);
            transform.position = new Vector3(transform.position.x, interpos, transform.position.z);
            yield return null;
            
        }
        while (goal <= t)
        {
            t -= 0.01f;

            interpos = (lowerBound * (1 - t) + upperBound * t);
            transform.position = new Vector3(transform.position.x, interpos, transform.position.z);
            yield return null;

        }
    }
}
