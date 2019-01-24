using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour {
//GameObject DeathTest;
    float velocity = 1;

    Vector3 bobbing = new Vector3();
    Vector3 ogPos = new Vector3();
    Vector3 temp = new Vector3 ();

    void Start () {
        //DeathTest = GameObject.Find("DeathTest");
        ogPos = this.transform.position;

    }

    void Update() {



        bobbing.z += velocity * Time.deltaTime;
        temp = new Vector3(ogPos.x, ogPos.y, bobbing.z);
        if (this.transform.position.z >= ogPos.z + 1) { velocity = -5; }
        else if (this.transform.position.z <= ogPos.z-2) { velocity = 1; }
                this.transform.position = temp;


    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("YOU DIED.");
    }
    
}
