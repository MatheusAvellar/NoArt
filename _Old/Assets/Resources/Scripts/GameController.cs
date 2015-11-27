using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	
	private Text langTxt;
	private Text playTxt;

	private GameObject FadeOut;

	void Start() {
		PlayerPrefs.SetString ("lang", "EN");
		langTxt = GameObject.FindGameObjectWithTag ("langBtn").GetComponent<Text> ();
		playTxt = GameObject.FindGameObjectWithTag ("playBtn").GetComponent<Text> ();
		langTxt.text = "EN";
		playTxt.text = "Play";

		FadeOut = Resources.Load ("Faders/FadeOutScene") as GameObject;
	}

	public void ChangeScene (int l) {
		Application.LoadLevel (l);
		Instantiate (FadeOut, new Vector3(0, 0, 0), Quaternion.identity);
	}

	public void ChangeLang () {
		if (PlayerPrefs.GetString ("lang") == "EN") {
			PlayerPrefs.SetString ("lang", "PT");
			langTxt.text = "PT";
			playTxt.text = "Jogar";
		} else {
			PlayerPrefs.SetString ("lang", "EN");
			langTxt.text = "EN";
			playTxt.text = "Play";
		}
	}
}
