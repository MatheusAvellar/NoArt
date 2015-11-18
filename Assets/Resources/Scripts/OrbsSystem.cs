using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class OrbsSystem : MonoBehaviour {

	private float _x, _y;
	private int bounds;
	public string reward;
	private string[] rewards = new string[10];
	private const bool O = false;
	private const bool I = true;
	private GameObject HUD;
	public bool isTouched;

	private float X {
		get { return this.gameObject.transform.position.x; }
		set { this.transform.position = new Vector2 (value, this.transform.position.y); }
	}

	private float Y {
		get { return this.gameObject.transform.position.y; }
		set { this.transform.position = new Vector2 (this.transform.position.x, value); }
	}

	void Awake () {
		HUD = GameObject.FindGameObjectWithTag ("HUD");
		HUD.SetActive (O);
	}

	void Start () {
		rewards [0] = reward;
		this.gameObject.transform.GetChild (0).GetChild (0).gameObject.GetComponent<Text> ().text = rewards [0];
	}

	void Update () {
		if (isTouched) {
			GetReward ();
			Destroy(this.gameObject);
		}
	}

	private void GetReward() {
		if (reward == rewards [0]) {
			HUD.SetActive (I);

			reward = string.Empty;
		}
	}	
}
