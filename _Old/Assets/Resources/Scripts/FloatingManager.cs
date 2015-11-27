using UnityEngine;
using System.Collections;

public class FloatingManager : MonoBehaviour {

	private GameObject[] floaterObj;

	void Start () {
		floaterObj = GameObject.FindGameObjectsWithTag ("Floater");
	}

	void Update () {

		for (int i = 0; i < floaterObj.Length; i++) {
			//hm
		}
	}
}
