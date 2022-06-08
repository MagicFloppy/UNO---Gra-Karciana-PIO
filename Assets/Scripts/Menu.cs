using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Menu : MonoBehaviour {

    public GameObject[] toggles = new GameObject[5];


public void play() { //finds the toggle that has been clicked to determine number of AI players
		for (int i = 0; i < 5; i++) {
			if (toggles[i].GetComponent<Toggle>().isOn) {
				Control.numbOfAI = i + 1;
				break;
			}
		}
		UnityEngine.SceneManagement.SceneManager.LoadScene("Main"); //loading of the play screen
	}

    public void exit() { //exits the app
		Application.Quit ();
	}

}