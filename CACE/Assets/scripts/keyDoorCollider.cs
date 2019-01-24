using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyDoorCollider : MonoBehaviour {

    keyDoorScript parent;
	// Use this for initialization
	void Start () {
        parent = GetComponentInParent<keyDoorScript>();
	}

    private void OnTriggerEnter(Collider other)
    {
        //print("collidre hit");
        parent.OnChildTriggerEnter(other);
    }
}
