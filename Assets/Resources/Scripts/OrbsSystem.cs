using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class OrbsSystem : MonoBehaviour {

	private float _x, _y;
	public int ID;
	private int life;
	private const bool O = false;
	private const bool I = true;
	public bool isTouched;
	public string reward;

	private GameObject HUD;
	public Sprite[] orbImage;
	SpriteRenderer orbRenderer;

	private string[] rewards = {
		"Beautifier Orb",
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
		HUD = GameObject.FindGameObjectWithTag ("HUD") as GameObject;
		if(ID == 1) HUD.SetActive (O);
		orbImage = Resources.LoadAll<Sprite> ("Sprites/orb");
	}

	void Start () {
		orbRenderer = GameObject.Find ("Orbs").transform.GetComponentInChildren<SpriteRenderer> ();
		this.gameObject.transform.GetChild (0).GetChild (0).gameObject.GetComponent<Text> ().text = rewards [ID];
	}

	void Update () {
		if (isTouched) {
			GetReward ();
		}
	}

	private void GetReward() {
		if (reward == rewards [0]) {
			orbRenderer.sprite = orbImage[0];
			Destroy(this.gameObject);

		} else if (reward == rewards [1]) {
			HUD.SetActive (I);
			reward = string.Empty;
			Destroy(this.gameObject);
		}

	}	
}
