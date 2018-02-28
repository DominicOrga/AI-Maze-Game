using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapControl : MonoBehaviour {

	public void LoadMapScene(string mapScene) {
        Scene scene = SceneManager.GetSceneByName(mapScene);

        if (scene.isLoaded) {
            SceneManager.UnloadScene(sceneName: mapScene);
        }


        SceneManager.LoadScene(sceneName: mapScene);
    }
}
