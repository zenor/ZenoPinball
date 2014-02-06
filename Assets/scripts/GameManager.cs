using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	const string PPKEY_HI_SCORE_1 = "HiScore1";

	public GameObject scoreTextObject;
	public GameObject hiScoreTextObject;
	public GameObject ballsRemainingTextObject;
	public GameObject plunger;

	TextMesh _scoreText;
	TextMesh _hiScoreText;
	TextMesh _ballsRemainingText;

	int _score;
	int _hiScore;
	int _ballsRemaining = 2;

	// Use this for initialization
	void Start () {
		_hiScore = PlayerPrefs.GetInt(PPKEY_HI_SCORE_1, 0);

		_scoreText = scoreTextObject.GetComponent<TextMesh>();
		setScoreText();

		_hiScoreText = hiScoreTextObject.GetComponent<TextMesh>();
		setHiScoreText();

		_ballsRemainingText = ballsRemainingTextObject.GetComponent<TextMesh>();
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
		if (_ballsRemaining >= 0) {
			setBallsRemainingText();
			StartCoroutine(ReloadBall());
		}
		else
			GameOver();
	}

	public IEnumerator ReloadBall() {
		yield return new WaitForSeconds(2);
		plunger.GetComponent<Plunger>().Reload();
	}

	void GameOver() {
		if (_score > _hiScore) {
			_hiScore = _score;
			PlayerPrefs.SetInt(PPKEY_HI_SCORE_1, _hiScore);
			setHiScoreText();
		}
		_ballsRemainingText.text = "Game Over";
	}

	void setScoreText() {
		_scoreText.text = "Score: " + _score;
	}

	void setHiScoreText() {
		_hiScoreText.text = "Hi Score: " + _hiScore;
	}

	void setBallsRemainingText() {
		_ballsRemainingText.text = "Balls Remaining: " + _ballsRemaining;
	}

	void OnGUI() {
		//GUI.Label(new Rect(10, 0, 100, 50), "Score: " + _score);
	} 
}
