using UnityEngine;
using System.Collections;

public class BreakOut : MonoBehaviour, ITriggerable {

	public GameObject MainGameMode;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Trigger() {
		MainGameMode.SetActive(false);
	}
}
