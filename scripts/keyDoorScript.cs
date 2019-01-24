using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyDoorScript : MonoBehaviour {

    private IEnumerator coroutine;
    // deg
    public float closedRot = 0f;
    public float openRot = 90f;
    public float speed = 0.1f;
    bool done = false;
    float t = 0;
    float interpos;

    public GameObject gameObject;
    GameObject col;
    public playerController pc;

    public Text txt;

    // Use this for initialization
    void Start () {
        gameObject = GetComponent<GameObject>();
        col = gameObject.transform.GetChild(1).gameObject as GameObject;
        txt = gameObject.GetComponent<Text>();
        closedRot = gameObject.transform.rotation.y;
        openRot = closedRot + 90;
    }

    public void OnChildTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            pc = other.GetComponent<playerController>();
            if (pc.isHoldingKey)
            {
                // open door
                coroutine = Open(1);
                StartCoroutine(coroutine);
                // take key
                pc.isHoldingKey = false;
                txt.text = "Open";
            }
        }
    }

    IEnumerator Open(float goal)
    {
        while(goal >= t)
        {
            t += speed * Time.deltaTime;

            interpos = (openRot * (1 - t) + closedRot * t);
            transform.rotation = Quaternion.Euler(0, interpos, 0);
            yield return null;
        }
        if(goal <= t)
        {
            StopCoroutine(coroutine);
        }
    }
}
