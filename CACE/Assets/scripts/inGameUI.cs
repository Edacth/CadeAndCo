using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inGameUI : MonoBehaviour {

    playerController pc;
    public Toggle t;

    int lives;
    public Image h2;
    public Image h3;

	// Use this for initialization
	void Start () {
        pc = FindObjectOfType<playerController>();
        t = GetComponentInChildren<Toggle>();
        t.isOn = false;
        lives = pc.health;
    }

    // Update is called once per frame
    void Update () {
        t.isOn = pc.isHoldingKey;
        lives = pc.health;

        h2.enabled = lives > 1;
        h3.enabled = lives > 2;
    }
}
