using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	const string PPKEY_HI_SCORE_1 = "HiScore1";

	public TextMesh scoreTextObject;
	public TextMesh hiScoreTextObject;
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
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddPoints(int points) {
		_score += points;
		OnGUI();
		setScoreText();
	}

	public void BallOver() {
		_ballsRemaining--;
		gate.Open();

		if (_ballsRemaining >= 0) {
			setBallsRemainingText();
			StartCoroutine(ReloadBall());
		}
		else
			GameOver();
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
		ballsRemainingTextObject.text = "Game Over";
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
