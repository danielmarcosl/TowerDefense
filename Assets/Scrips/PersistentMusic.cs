using UnityEngine;
using System.Collections;

public class PersistentMusic : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;

	void Awake() {
		DontDestroyOnLoad (gameObject);
		Debug.Log ("Don't destroy on load: " + name);
	}

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}

	void OnLevelWasLoaded (int level) {
		AudioClip thisLevelMusic = levelMusicChangeArray [level];

		Debug.Log("Playing clip: " +  thisLevelMusic);

		if (thisLevelMusic) { // If there's some music attached
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
