using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public LevelManager levelManager;

	private PersistentMusic musicManager;
	
	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<PersistentMusic> ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();

		volumeSlider.value = PlayerPrefsManager.GetMasterVolume ();
	}
	
	// Update is called once per frame
	void Update () {
		
		musicManager.SetVolume (volumeSlider.value);
	}

	public void SaveAndExit() {
		PlayerPrefsManager.SetMasterVolume (volumeSlider.value);

		musicManager.SetVolume (volumeSlider.value);

		levelManager.LoadLevel ("01a_Start");
	}
}
