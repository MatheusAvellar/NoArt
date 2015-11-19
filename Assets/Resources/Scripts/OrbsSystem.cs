using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class OrbsSystem : MonoBehaviour {

	private float _x, _y;
	private const bool O = false;
	private const bool I = true;
	public bool isTouched;
	public string reward;
	public int ID;

	private GameObject HUD;
	private Sprite orbImage;

	private string[] rewards = {
		"Beatifier Orb",
		"HUD"
	};


	private float X {
		get { return this.gameObject.transform.position.x; }
		set { this.transform.position = new Vector2 (value, this.transform.position.y); }
	}

	private float Y {
		get { return this.gameObject.transform.position.y; }
		set { this.transform.position = new Vector2 (this.transform.position.x, value); }
	}

	void Awake () {
		HUD = Resources.Load ("Prefabs/HUD") as GameObject;
		orbImage = Resources.Load("Sprites/orb", typeof(Sprite)) as Sprite;
	}

	void Start () {
		this.gameObject.transform.GetChild (0).GetChild (0).gameObject.GetComponent<Text> ().text = rewards [ID];
	}

	void Update () {
		if (isTouched) {
			GetReward ();
		}
	}

	private void GetReward() {
		if (reward == rewards [0]) {
			HUD.SetActive (I);
			reward = string.Empty;
			Destroy(this.gameObject);

		} else if (reward == rewards [1]) {
			GameObject.Find("Orbs").transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = orbImage;
			Destroy(this.gameObject);
		}

	}	
}
