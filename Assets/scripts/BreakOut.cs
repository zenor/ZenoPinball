using UnityEngine;
using System.Collections;

public class BreakOut : MonoBehaviour, ITriggerable, IResetable {

	public GameObject MainGameMode;
	public Transform Block;

	GameObject BreakoutMode;

	public int blocksHoriz = 8;
	public int blocksVert = 8;

	const float xPos = -3.5f;

	// Use this for initialization
	void Start () {
		Setup();	
	}
	
	// Update is called once per frame
	void Update () {
		// for debug
		if (Input.GetKeyUp(KeyCode.B))
			Trigger();
	}

	void Setup() {
		BreakoutMode = new GameObject("Blocks");
		BreakoutMode.transform.parent = transform;
		BreakoutMode.transform.localPosition = Vector3.zero;
		BreakoutMode.transform.rotation = transform.rotation;

		for (int x = 0; x < blocksHoriz; ++x) {
			for (int z = 0; z < blocksVert; ++z) {
				Transform newBlock = (Transform)Instantiate(Block);
				newBlock.parent = BreakoutMode.transform;
				newBlock.localPosition = new Vector3(x * 1f, BreakoutMode.transform.position.y + 0.2f, z * 1f);
				newBlock.transform.rotation = BreakoutMode.transform.rotation;
			}
		}
		transform.localPosition = new Vector3(xPos, transform.position.y, transform.position.z);

		BreakoutMode.SetActive(false);
	}

	public void Trigger() {
		MainGameMode.SetActive(false);
		BreakoutMode.SetActive(true);
	}

	public void Reset() {

	}
}
