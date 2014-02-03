using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject scoreTextObject;
	public GameObject plunger;

	TextMesh _scoreText;

	int _score;
	int _ballsRemaining = 2;

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
		OnGUI();
		_scoreText.text = "Score: " + _score;
	}

	public void BallOver() {
		_ballsRemaining--;
		if (_ballsRemaining >= 0)
			StartCoroutine(ReloadBall());
	}

	public IEnumerator ReloadBall() {
		yield return new WaitForSeconds(2);
		plunger.GetComponent<Plunger>().Reload();
	}

	void OnGUI() {
		GUI.Label(new Rect(10, 0, 100, 50), "Score: " + _score);
	} 
}
