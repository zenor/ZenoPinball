using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	const string PPKEY_HI_SCORE_1 = "HiScore1";

	public GameObject scoreTextObject;
	public GameObject hiScoreTextObject;
	public GameObject plunger;

	TextMesh _scoreText;
	TextMesh _hiScoreText;

	int _score;
	int _hiScore;
	int _ballsRemaining = 2;

	// Use this for initialization
	void Start () {
		_hiScore = PlayerPrefs.GetInt(PPKEY_HI_SCORE_1, 0);

		_scoreText = scoreTextObject.GetComponent<TextMesh>();
		_scoreText.text = "Score: 0";

		_hiScoreText = hiScoreTextObject.GetComponent<TextMesh>();
		_hiScoreText.text = "Hi Score: " + _hiScore;
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
		else
			GameOver();
	}

	public IEnumerator ReloadBall() {
		yield return new WaitForSeconds(2);
		plunger.GetComponent<Plunger>().Reload();
	}

	void GameOver() {
		if (_score > _hiScore)
			PlayerPrefs.SetInt(PPKEY_HI_SCORE_1, _score);
	}

	void OnGUI() {
		GUI.Label(new Rect(10, 0, 100, 50), "Score: " + _score);
	} 
}
