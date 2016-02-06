using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_value";
	const string LEVEL_KEY = "level_unlocked_";
	const string DIFFICULTY_KEY = "difficulty";

	// MASTER_VOLUME_KEY Methods
	public static void SetMasterVolume (float volume) {
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError ("Master volume out of range");
		}
	}

	public static float GetMasterVolume () {
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}

	// LEVEL_KEY Methods
	public static void UnlockLevel (int level) {
		if ((level <= SceneManager.sceneCountInBuildSettings - 1) && (level >= 0)) {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString (), 1); // Use 1 for true
		} else {
			Debug.LogError ("Trying to unlock level not in build order");
		}
	}

	public static bool IsLevelUnlocked (int level) {
		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString());
		bool isLevelUnlocked = (levelValue == 1);

		if ((level <= SceneManager.sceneCountInBuildSettings - 1) && (level >= 0)) {
			return isLevelUnlocked;
		} else {
			Debug.LogError ("Trying to query level not in build order");
			return false;
		}
	}

	// DIFFICULTY_KEY Methods
	public static void SetDifficulty (int difficulty) {
		if (difficulty >= 0 && difficulty <= 1) {
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError ("Difficulty out of range");
		}
	}

	public static int GetDifficulty () {
		return PlayerPrefs.GetFloat (DIFFICULTY_KEY);
	}
}
