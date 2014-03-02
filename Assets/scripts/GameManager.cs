using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

	List<IResetable> _resetables = new List<IResetable>();

	// Use this for initialization
	void Start () {
		_hiScore = PlayerPrefs.GetInt(PPKEY_HI_SCORE_1, 0);
		setScoreText();
		setHiScoreText();
		setBallsRemainingText();
		Message(Constants.Messages.StartGoodLuck);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyUp(KeyCode.Escape))
			Application.Quit();
	}

	/// <summary>
	/// Adds a GameObject to the list of things to be reset at gameover
	/// </summary>
	/// <param name="go">Component to reset at gameover.</param>
	public void AddResetableObject(IResetable component) {
		_resetables.Add(component);
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
			Message(Constants.Messages.BallOver);
			setBallsRemainingText();
			StartCoroutine(ReloadBall());
		}
		else {
			Message(Constants.Messages.GameOver);
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
		Reset();
	}

	void Reset() {
		foreach (IResetable component in _resetables) {
			component.Reset();
		}
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
