using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	int _score;
	int _balls = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddPoints(int points) {
		_score += points;
		Debug.Log("Added " + points + "to total score upto " + _score);
		OnGUI();
	}

	void OnGUI() {
		GUI.Label(new Rect(10, 0, 100, 50), "Score: " + _score);
	} 
}
