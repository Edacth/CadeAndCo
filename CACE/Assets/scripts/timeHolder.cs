using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeHolder : MonoBehaviour {

    public string score;

	// Use this for initialization
	void Awake ()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("const");
        if(go.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);	
	}
}
