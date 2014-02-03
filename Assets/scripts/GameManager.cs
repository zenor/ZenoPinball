using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject scoreTextObject;
	TextMesh _scoreText;

	int _score;
	int _balls = 3;

	// Use this for initialization
	void Start () {
		_scoreText = scoreTextObject.GetComponent<TextMesh>();
		_scoreText.text = "Score: 0";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddPoints(int points) {
		_score += points;
		Debug.Log("Added " + points + "to total score upto " + _score);
		OnGUI();
		_scoreText.text = "Score: " + _score;
	}

	void OnGUI() {
		GUI.Label(new Rect(10, 0, 100, 50), "Score: " + _score);
	} 
}
