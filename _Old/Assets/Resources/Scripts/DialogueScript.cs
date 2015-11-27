using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueScript : MonoBehaviour {

	private int curSpeech = 0;
	private string[] stringArray;
	private GameObject conversation;
	private GameObject conversationAddons;
	private float speechDelay = 0.02f;
	private Text txt;
	private bool hasEnded;

	void Start () {
		if (PlayerPrefs.GetString ("lang") == "PT") {
			stringArray = new string[] {
				"Você: O que... O que é este lugar? Como eu cheguei aqui?",
				"????: Você está em um jogo. Um jogo sem arte.",
				"????: A arte deste jogo foi roubada pelo bruto Rei Triângulo. Você deve impedí-lo!",
				"Você: Tudo bem. Mas como eu encontro ele?",
				"????: Ah, isso é simples. Assim como qualquer outro jogo de plataforma: Vá para a direita!"
			};
		} else {
			stringArray = new string[] {
				"You: Wha... What is this place? How did I get here?",
				"???: You're inside a game. A game with no art.",
				"???: The art of this game was stolen by the evil Triangle King. You must recover it!",
				"You: Alright. But how do I find him?",
				"???: Oh, that's simple. Just like any other platform game: Head right!"
			};
		}
		conversation = GameObject.FindGameObjectWithTag ("Conversation");
		conversationAddons = GameObject.FindGameObjectWithTag ("ConversationAddon");
		txt = conversation.GetComponent<Text> ();
		txt.text = "";
		hasEnded = false;
		StartCoroutine("Type");
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && hasEnded) {
			txt.text = "";
			if (curSpeech < stringArray.Length - 1) {
				curSpeech++;
				StartCoroutine("Type");
			} else {
				conversationAddons.SetActive (false);
			}
		}
	}

	IEnumerator Type() {
		hasEnded = false;
		conversationAddons.SetActive (hasEnded);
		for (int i = 0; i < stringArray[curSpeech].Length; i++) {
			yield return new WaitForSeconds(speechDelay);
			try {
				txt.text += (stringArray[curSpeech][i]).ToString();
			} catch {}
			if (curSpeech == 0 || curSpeech == 3) { 
				txt.color = Color.black;
			} else {
				txt.color = Color.blue;
			}
		}
		hasEnded = true;
		conversationAddons.SetActive (hasEnded);
	}
}
