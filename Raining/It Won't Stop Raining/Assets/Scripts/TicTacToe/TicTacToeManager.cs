﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TicTacToeManager : MonoBehaviour {

	GameObject[][] tiles;
	public AudioClip xSound,oSound;

	bool playerTurn;
	float turnDelay;
	public float turnDelayTime;
	public float scale;
	bool ended;

	// Use this for initialization
	void Start () {
		Vector2 pos = gameObject.transform.position;
		tiles = new GameObject[3][];
		for (int i = 0; i < tiles.Length; i++) {
			tiles [i] = new GameObject[3];
			for (int j = 0; j < tiles [i].Length; j++) {
				GameObject tile = (GameObject)(Resources.Load ("Prefabs/TicTacToe/TicTacTile", typeof(GameObject)));
				tile.transform.position = pos + new Vector2 (i * scale,-1 * j * scale);
				tile.transform.localScale = new Vector2 (scale,scale);
				tiles[i][j] = GameObject.Instantiate (tile);
				var ttt = tiles[i][j].GetComponent<TicTacTile> ();
				ttt.x = i;
				ttt.y = j;
				ttt.parent = this;
			}
		}
		playerTurn = true;
		turnDelay = 0;
		ended = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!ended && isEndOfGame ()) {
			Debug.Log ("END");
			ended = true;
		}
		if (!playerTurn && !ended) {
			if (turnDelay <= 0) {
				makeComputerMove ();
			} else {
				turnDelay -= Time.deltaTime;
			}
		}
	}

	public void handleClick(TicTacTile t){
		if (playerTurn && t.state == 0) {
			t.state = 1;
			t.GetComponent<SpriteRenderer> ().sprite = t.xImage;
			playerTurn = false;
			turnDelay = turnDelayTime;
			AudioSource.PlayClipAtPoint (xSound,new Vector2(0,0));
			if (isEndOfGame ()) {
				Debug.Log ("You Won!");
				ended = true;
				SceneManager SM = GameObject.Find ("SceneManager").GetComponent<SceneManager>();
				SM.MoveToScene (0);
			}
		}
	}

	void makeComputerMove(){
		//(0,0)
		if (tiles [0] [0].GetComponent<TicTacTile> ().state == 0) {
			if (tiles [0] [1].GetComponent<TicTacTile> ().state == 1 && tiles [0] [2].GetComponent<TicTacTile> ().state == 1) {
				compPlay (0, 0);
				return;
			}
			if (tiles [1] [1].GetComponent<TicTacTile> ().state == 1 && tiles [2] [2].GetComponent<TicTacTile> ().state == 1) {
				compPlay (0, 0);
				return;
			}
			if (tiles [1] [0].GetComponent<TicTacTile> ().state == 1 && tiles [2] [0].GetComponent<TicTacTile> ().state == 1) {
				compPlay (0, 0);
				return;
			}
		}
		if (tiles [0] [1].GetComponent<TicTacTile> ().state == 0) {
			if (tiles [0] [0].GetComponent<TicTacTile> ().state == 1 && tiles [0] [2].GetComponent<TicTacTile> ().state == 1) {
				compPlay (0, 1);
				return;
			}
			if (tiles [1] [1].GetComponent<TicTacTile> ().state == 1 && tiles [2] [1].GetComponent<TicTacTile> ().state == 1) {
				compPlay (0, 1);
				return;
			}
		}
		if (tiles [0] [2].GetComponent<TicTacTile> ().state == 0) {
			if (tiles [0] [1].GetComponent<TicTacTile> ().state == 1 && tiles [0] [0].GetComponent<TicTacTile> ().state == 1) {
				compPlay (0, 2);
				return;
			}
			if (tiles [1] [1].GetComponent<TicTacTile> ().state == 1 && tiles [2] [0].GetComponent<TicTacTile> ().state == 1) {
				compPlay (0, 2);
				return;
			}
			if (tiles [1] [2].GetComponent<TicTacTile> ().state == 1 && tiles [2] [2].GetComponent<TicTacTile> ().state == 1) {
				compPlay (0, 2);
				return;
			}
		}
		if (tiles [1] [0].GetComponent<TicTacTile> ().state == 0) {
			if (tiles [0] [0].GetComponent<TicTacTile> ().state == 1 && tiles [2] [0].GetComponent<TicTacTile> ().state == 1) {
				compPlay (1, 0);
				return;
			}
			if (tiles [1] [1].GetComponent<TicTacTile> ().state == 1 && tiles [1] [2].GetComponent<TicTacTile> ().state == 1) {
				compPlay (1, 0);
				return;
			}
		}
		if (tiles [1] [1].GetComponent<TicTacTile> ().state == 0) {
			if (tiles [0] [0].GetComponent<TicTacTile> ().state == 1 && tiles [2] [2].GetComponent<TicTacTile> ().state == 1) {
				compPlay (1, 1);
				return;
			}
			if (tiles [0] [1].GetComponent<TicTacTile> ().state == 1 && tiles [2] [1].GetComponent<TicTacTile> ().state == 1) {
				compPlay (1, 1);
				return;
			}
			if (tiles [0] [2].GetComponent<TicTacTile> ().state == 1 && tiles [2] [0].GetComponent<TicTacTile> ().state == 1) {
				compPlay (1, 1);
				return;
			}
			if (tiles [1] [0].GetComponent<TicTacTile> ().state == 1 && tiles [1] [2].GetComponent<TicTacTile> ().state == 1) {
				compPlay (1, 1);
				return;
			}
		}
		if (tiles [1] [2].GetComponent<TicTacTile> ().state == 0) {
			if (tiles [0] [2].GetComponent<TicTacTile> ().state == 1 && tiles [2] [2].GetComponent<TicTacTile> ().state == 1) {
				compPlay (1, 2);
				return;
			}
			if (tiles [1] [1].GetComponent<TicTacTile> ().state == 1 && tiles [1] [0].GetComponent<TicTacTile> ().state == 1) {
				compPlay (1, 2);
				return;
			}
		}
		if (tiles [2] [0].GetComponent<TicTacTile> ().state == 0) {
			if (tiles [0] [0].GetComponent<TicTacTile> ().state == 1 && tiles [1] [0].GetComponent<TicTacTile> ().state == 1) {
				compPlay (2, 0);
				return;
			}
			if (tiles [0] [2].GetComponent<TicTacTile> ().state == 1 && tiles [1] [1].GetComponent<TicTacTile> ().state == 1) {
				compPlay (2, 0);
				return;
			}
			if (tiles [2] [2].GetComponent<TicTacTile> ().state == 1 && tiles [2] [1].GetComponent<TicTacTile> ().state == 1) {
				compPlay (2, 0);
				return;
			}
		}
		if (tiles [2] [1].GetComponent<TicTacTile> ().state == 0) {
			if (tiles [2] [0].GetComponent<TicTacTile> ().state == 1 && tiles [2] [2].GetComponent<TicTacTile> ().state == 1) {
				compPlay (2, 1);
				return;
			}
			if (tiles [0] [1].GetComponent<TicTacTile> ().state == 1 && tiles [1] [1].GetComponent<TicTacTile> ().state == 1) {
				compPlay (2, 1);
				return;
			}
		}
		if (tiles [2] [2].GetComponent<TicTacTile> ().state == 0) {
			if (tiles [0] [0].GetComponent<TicTacTile> ().state == 1 && tiles [1] [1].GetComponent<TicTacTile> ().state == 1) {
				compPlay (2, 2);
				return;
			}if (tiles [0] [2].GetComponent<TicTacTile> ().state == 1 && tiles [1] [2].GetComponent<TicTacTile> ().state == 1) {
				compPlay (2, 2);
				return;
			}if (tiles [2] [0].GetComponent<TicTacTile> ().state == 1 && tiles [2] [1].GetComponent<TicTacTile> ().state == 1) {
				compPlay (2, 2);
				return;
			}
		}
		List<int> playables = new List<int>();
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				if (tiles [i] [j].GetComponent<TicTacTile> ().state == 0) {
					playables.Add (i * 3 + j);
				}
			}
		}
		int play = playables[Random.Range(0,playables.Count - 1)];
		compPlay (play / 3, play % 3);
	}

	bool isEndOfGame(){
		for (int j = 0; j < 3; j++) {
			if ((tiles [0] [j].GetComponent<TicTacTile> ().state == 1 || tiles [0] [j].GetComponent<TicTacTile> ().state == 2) && tiles [0] [j].GetComponent<TicTacTile> ().state == tiles [1] [j].GetComponent<TicTacTile> ().state && tiles [0] [j].GetComponent<TicTacTile> ().state == tiles [2] [j].GetComponent<TicTacTile> ().state) {
				return true;
			}
			if ((tiles [j] [0].GetComponent<TicTacTile> ().state == 1 || tiles [j] [0].GetComponent<TicTacTile> ().state == 2) && tiles [j] [0].GetComponent<TicTacTile> ().state == tiles [j] [1].GetComponent<TicTacTile> ().state && tiles [j] [0].GetComponent<TicTacTile> ().state == tiles [j] [2].GetComponent<TicTacTile> ().state) {
				return true;
			}
		}
		if ((tiles [0] [0].GetComponent<TicTacTile> ().state == 1 || tiles [0] [0].GetComponent<TicTacTile> ().state == 2) && tiles [0] [0].GetComponent<TicTacTile> ().state == tiles [1] [1].GetComponent<TicTacTile> ().state && tiles [0] [0].GetComponent<TicTacTile> ().state == tiles [2] [2].GetComponent<TicTacTile> ().state) {
			return true;
		}
		if ((tiles [2] [0].GetComponent<TicTacTile> ().state == 1 || tiles [2] [0].GetComponent<TicTacTile> ().state == 2) && tiles [2] [0].GetComponent<TicTacTile> ().state == tiles [1] [1].GetComponent<TicTacTile> ().state && tiles [2] [0].GetComponent<TicTacTile> ().state == tiles [0] [2].GetComponent<TicTacTile> ().state) {
			return true;
		}
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				if (tiles [i] [j].GetComponent<TicTacTile> ().state == 0) {
					return false;
				}
			}
		}
		return true;
	}

	void compPlay(int x,int y){
		tiles [x] [y].GetComponent<SpriteRenderer> ().sprite = tiles [x] [y].GetComponent<TicTacTile> ().oImage;
		tiles [x] [y].GetComponent<TicTacTile> ().state = 2;
		AudioSource.PlayClipAtPoint (oSound, new Vector2 (0, 0));
		if (isEndOfGame ()) {
			Debug.Log ("Comp Won!");
			ended = true;
			SceneManager SM = GameObject.Find ("SceneManager").GetComponent<SceneManager>();
			SM.MoveToScene (0);
		} else {
			playerTurn = true;
		}
	}
}
