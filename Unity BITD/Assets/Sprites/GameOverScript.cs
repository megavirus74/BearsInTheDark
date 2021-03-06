﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {
    public static bool isGameOver = false;
    private float timer;
    private bool isHighScoreBeaten = false;
    public GameObject GameOverScreen;
    public GameObject Instruction;

	// Use this for initialization
	void Start () {
        LevelManager.LevelTimerText.GetComponent<Animator>().Play("UIGameOverTime");
		Instantiate(GameOverScreen, new Vector3(Camera.main.transform.position.x,Camera.main.transform.position.y,Camera.main.transform.position.z+26),Camera.main.transform.rotation);
        timer = 2f;
        if (PlayerPrefs.GetFloat("Best time")<LevelManager.TimerLevel) {
            PlayerPrefs.SetFloat("Best time",LevelManager.TimerLevel);
            isHighScoreBeaten = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    timer -= Time.deltaTime;
        if (timer<=0) {
        timer = 50000f;
        var cloneInstruction = (GameObject) Instantiate(Instruction);
            foreach (var obj in GameObject.FindGameObjectsWithTag("UI")) {
                if (obj.name == "GamePlayPanel") cloneInstruction.transform.SetParent(obj.transform,false);
            }
            if (isHighScoreBeaten)
            LevelManager.LevelTimerText.GetComponent<Text>().text = "New Highscore!\n" +
                                                                        LevelManager.LevelTimerText.GetComponent<Text>()
                                                                            .text + "\n";
            else
                LevelManager.LevelTimerText.GetComponent<Text>().text = "Your time:\n" +
                                                                            LevelManager.LevelTimerText.GetComponent<Text>()
                                                                                .text + "\n";
            
	    }
	}
}
