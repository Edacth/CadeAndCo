using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupAnimator : MonoBehaviour {

    public int rotSpeed = 10;

    // Update is called once per frame
    void Update ()
    {
        transform.Rotate(new Vector3(0, rotSpeed / 10f, rotSpeed / 10f));
	}
}
