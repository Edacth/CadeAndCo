using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inGameUI : MonoBehaviour {

    playerController pc;
    public Toggle t;
    public timeHolder th;

    int lives;
    public Image h2;
    public Image h3;
    public Text timeTxt;

	// Use this for initialization
	void Start () {
        pc = FindObjectOfType<playerController>();
        t = GetComponentInChildren<Toggle>();
        th = GameObject.FindGameObjectWithTag("const").GetComponent<timeHolder>();
        t.isOn = false;
        lives = pc.health;
    }

    // Update is called once per frame
    void Update () {
        t.isOn = pc.isHoldingKey;
        lives = pc.health;

        h2.enabled = lives > 1;
        h3.enabled = lives > 2;

        timeTxt.text = Mathf.Round(Time.timeSinceLevelLoad).ToString();
        th.score = timeTxt.text;
    }
}
