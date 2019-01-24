using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowController : MonoBehaviour {

    public float distance = 10f;
    public float speed = 10f;
    public float recharge = 4f; // seconds
    public float shootTime = 0.5f;
    public float elapsed = 0f;

    public playerController pc;

    public bool hitThisCycle = false;
    public bool shooting = false; // coroutine running

    private Vector3 interpos;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
        pc = FindObjectOfType<playerController>();
    }
    void Update()
    {
        elapsed += Time.deltaTime;
        if (shooting)
        {
            if(elapsed >= shootTime)
            {
                // reset
                transform.position = new Vector3(startPos.x, startPos.y, startPos.z);
                shooting = false;
                hitThisCycle = false;
                elapsed = 0f;
            }
            else
            {
                transform.position += transform.up * speed * Time.deltaTime;
            }
            
        }
        else
        {
            if (elapsed >= recharge)
            {
                shooting = true;
                elapsed = 0f;
            }
        }        
    }

    void OnTriggerEnter(Collider other)
    {
        // hit && not hit this cycle
        if ( !hitThisCycle && other.CompareTag("player"))
        {
            pc.health--;
            hitThisCycle = true;
        }
    }

}
