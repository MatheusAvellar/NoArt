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
	private GameObject Vignette;
	private Sprite[] orbImage;
	private GameObject[] orbRenderer;

	private string[] rewards = {
		"Beautifier Orb",
		"HUD",
		"Vignette"
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
		Vignette = GameObject.FindGameObjectWithTag ("Vignette") as GameObject;
		if(ID == 1) HUD.SetActive (O);
		if(ID == 2) Vignette.SetActive (O);
		orbImage = Resources.LoadAll<Sprite> ("Sprites/orb");
	}

	void Start () {
		orbRenderer = GameObject.FindGameObjectsWithTag ("Orb");
		for (int i = 0; i < orbRenderer.Length - 1; i++) {
			orbRenderer[i].transform.GetComponentInChildren<SpriteRenderer> ();
		}
		this.gameObject.transform.GetChild (0).GetComponentInChildren<Text> ().text = rewards [ID];
	}

	void Update () {
		if (isTouched) {
			GetReward ();
		}
	}

	private void GetReward() {

		if (reward == rewards [0]) {
			for (int i = 0; i < orbRenderer.Length - 1; i++) {
				orbRenderer[i].transform.GetComponentInChildren<SpriteRenderer> ().sprite = orbImage[0];
			}
			Destroy(this.gameObject);

		} else if (reward == rewards [1]) {
			HUD.SetActive (I);
			reward = string.Empty;
			Destroy(this.gameObject);

		} else if (reward == rewards [2]) {
			Vignette.SetActive (I);
			reward = string.Empty;
			Destroy(this.gameObject);
		}

	}	
}
