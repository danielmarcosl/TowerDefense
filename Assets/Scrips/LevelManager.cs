using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;

	void Start () {
		autoLoadNextLevel ();
	}

	/**
	 * Charge the next level is there's a time set
	 **/
	void autoLoadNextLevel () {
		if (autoLoadNextLevelAfter == 0) {
			Debug.Log ("Level auto load disabled");
		} else {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter); 
		}
	}

	public void LoadLevel (string name) {
		SceneManager.LoadScene (name);
	}

	public void LoadNextLevel () {
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void QuitRequest () {
		Application.Quit ();
	}
}
