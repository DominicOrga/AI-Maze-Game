using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalControl : MonoBehaviour {

    bool isTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision) {
        if ((string.Equals(collision.tag, "Blip") || string.Equals(collision.tag, "Blob") && !isTriggered)) {
            LevelManager levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
            levelManager.SetGameWon(string.Equals(collision.tag, "Blip"));
            isTriggered = true;
        }
    }
}
