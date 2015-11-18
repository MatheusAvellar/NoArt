using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	
	private Text langTxt;
	private Text playTxt;

	void Awake() {
		//It works only on build :p
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 8;
	}

	void Start() {
		PlayerPrefs.SetString ("lang", "EN");
		langTxt = GameObject.FindGameObjectWithTag ("langBtn").GetComponent<Text> ();
		playTxt = GameObject.FindGameObjectWithTag ("playBtn").GetComponent<Text> ();
		langTxt.text = "Language: EN";
		playTxt.text = "Play";
	}

	public void ChangeScene (int l) {
		Application.LoadLevel (l);
	}

	public void ChangeLang () {
		if (PlayerPrefs.GetString ("lang") == "EN") {
			PlayerPrefs.SetString ("lang", "PT");
			langTxt.text = "Linguagem: PT";
			playTxt.text = "Jogar";
		} else {
			PlayerPrefs.SetString ("lang", "EN");
			langTxt.text = "Language: EN";
			playTxt.text = "Play";
		}
	}
}
