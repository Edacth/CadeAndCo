using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }
	

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            SceneManager.LoadScene("loseScene");
            print("collidre hit");
            Cursor.visible = true;
        }
    }
}
