using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyControl : MonoBehaviour {

    public void LoadMapScene() {
        SceneManager.LoadScene(sceneName: "MapScene");
    }

	public void SetDifficulty(int difficulty) {
        Preferences.Difficulty = difficulty;
    }
}
