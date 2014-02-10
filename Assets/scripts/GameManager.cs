using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	const string PPKEY_HI_SCORE_1 = "HiScore1";

	public TextMesh scoreTextObject;
	public TextMesh hiScoreTextObject;
	public TextMesh messages;
	public TextMesh ballsRemainingTextObject;
	public Plunger plunger;
	public Gate gate;

	int _score;
	int _hiScore;
	int _ballsRemaining = 2;

	// Use this for initialization
	void Start () {
		_hiScore = PlayerPrefs.GetInt(PPKEY_HI_SCORE_1, 0);
		setScoreText();
		setHiScoreText();
		setBallsRemainingText();
		Message("Good Luck");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddPoints(int points) {
		_score += points;
		setScoreText();
	}

	public void Message(string text) {
		messages.text = text;
		StopCoroutine("BlankMessage");
		StartCoroutine("BlankMessage");
	}

	IEnumerator BlankMessage() {
		yield return new WaitForSeconds(1);
		messages.text = "";
	}

	public void BallOver() {
		_ballsRemaining--;
		gate.Open();

		if (_ballsRemaining >= 0) {
			Message("Oh no!");
			setBallsRemainingText();
			StartCoroutine(ReloadBall());
		}
		else {
			Message("Game Over");
			GameOver();
		}
	}

	public IEnumerator ReloadBall() {
		yield return new WaitForSeconds(2);
		plunger.Reload();
	}

	void GameOver() {
		if (_score > _hiScore) {
			_hiScore = _score;
			PlayerPrefs.SetInt(PPKEY_HI_SCORE_1, _hiScore);
			setHiScoreText();
		}
		ballsRemainingTextObject.text = "Thanks for Playing!";
	}

	void setScoreText() {
		scoreTextObject.text = "Score: " + _score;
	}

	void setHiScoreText() {
		hiScoreTextObject.text = "Hi Score: " + _hiScore;
	}

	void setBallsRemainingText() {
		ballsRemainingTextObject.text = "Balls Remaining: " + _ballsRemaining;
	}

	void OnGUI() {
		//GUI.Label(new Rect(10, 0, 100, 50), "Score: " + _score);
	} 
}
