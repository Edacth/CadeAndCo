using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowController : MonoBehaviour {

    public float distance = 10f;
    public float speed = 0.1f;
    public float recharge = 4f; // seconds
    public float elapsed = 0f;

    public playerController pc;

    private bool hitThisCycle = false;
    public bool shooting = false; // coroutine running

    private IEnumerator coroutine;
    private float t = 0;
    private Vector3 interpos;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
        pc = GetComponent<playerController>();
    }
    void Update()
    {
        if (!shooting)
        {
            elapsed += Time.deltaTime;
        }

        if(elapsed >= recharge)
        {
            shooting = true;
            coroutine = Shoot(1);
            elapsed = 0f;          
            StartCoroutine(coroutine);
        }
    }
    IEnumerator Shoot(float goal)
    {
        while(t <= goal)
        {
            t += speed * Time.deltaTime;

            interpos =  new Vector3(startPos.x, startPos.y, distance * t + startPos.z * (1 - t));
            transform.position = interpos;
            yield return null;
        }
        if(t >= goal)
        {
            // reset
            transform.position = startPos;
            shooting = false;
            t = 0f;
            StopCoroutine(coroutine);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            // pc.take damage / reset to center of room
            // gameObject.SetActive(false)
        }
    }
}
