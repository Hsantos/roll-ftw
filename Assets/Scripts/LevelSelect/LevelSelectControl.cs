﻿using UnityEngine;
using System.Collections;

public class LevelSelectControl : MonoBehaviour {
	
	public Fader fader;
	
	// Use this for initialization
	void Start () {
		
		AudioHandler.Load ("selection");
		AudioHandler.Load ("cursor");

		GameState.CurrentLevel = GameState.MaxReachedLevel;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.UpArrow)) {
			GameState.CurrentLevel++;
			if (GameState.CurrentLevel > GameState.MaxReachedLevel)
				GameState.CurrentLevel = GameState.MaxReachedLevel;
			else
				AudioHandler.Play("cursor");
		}
		
		if (Input.GetKey (KeyCode.DownArrow)) {
			GameState.CurrentLevel--;
			if (GameState.CurrentLevel < 1)
				GameState.CurrentLevel = 1;
			else
				AudioHandler.Play("cursor");
		}
		
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return)) {
			if (fader == null) {
				StartGame();
			} else {
				fader.SetColor(new Color(1, 1, 1, 0));
				fader.Play(true, gameObject, "StartGame");
			}
			AudioHandler.Play("selection");
			this.enabled = false;
			return;
		}
		
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey(KeyCode.Escape)) {
			if (fader == null) {
				ReturnToTitleScreen();
			} else {
				fader.SetColor(new Color(0, 0, 0, 0));
				fader.Play(true, gameObject, "ReturnToTitleScreen");
			}
			AudioHandler.Play("selection");
			this.enabled = false;
			return;
		}
		
	}
	
	void StartGame() {
		GameState.LoadLevel ();
	}
	
	void ReturnToTitleScreen() {
		Application.LoadLevel ("TitleScreen");
	}
	
}
