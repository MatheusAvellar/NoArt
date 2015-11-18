using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OrbsSystem : MonoBehaviour {

	private float _x, _y;
	private int bounds;
	public string reward;
	private string[] rewards = new string[10];
	public bool isTouched;

	private float X {
		get { return this.gameObject.transform.position.x; }
		set { this.transform.position = new Vector3 (value, this.transform.position.y, this.transform.position.z); }
	}

	private float Y {
		get { return this.gameObject.transform.position.y; }
		set { this.transform.position = new Vector3 (this.transform.position.x, value, this.transform.position.z); }
	}

	void Start () {
		rewards [0] = "Framerate";
	}

	void Update () {
		if (isTouched)
			GetReward ();
	}

	private void GetReward() {
		if (reward == rewards [0]) {
			QualitySettings.vSyncCount = 1;
			Application.targetFrameRate = 60;
			reward = string.Empty;
		}
	}
}
