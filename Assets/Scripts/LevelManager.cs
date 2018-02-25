using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    /** 
     * TODO:
     * -- Instantiate player on random start node
     * -- Instantiate block on random goal node
     * -- Make camera follow player
     * -- Add public function that ends game.
     * -- Add start countdown
     **/

    public Camera camera;
    public RectTransform joystick;
    public BlipControl blipPrefab;
    //public Rigidbody2D blobPrefab;

    NodeGroup nodeGroup;
    NodeConnection nodeConnection;

    BlipControl blipControl;

    bool isGamePaused;

    // Use this for initialization
    void Start() {
        isGamePaused = false;
        nodeGroup = gameObject.GetComponent<NodeGroup>();
        nodeConnection = gameObject.GetComponent<NodeConnection>();

        int startNodeIdx = nodeGroup.RandomizeStartNodeIdx();
        int goalNodeIdx = nodeGroup.RandomizeGoalNodeIdx(startNodeIdx);

        Vector2 startPosition = new Vector2(nodeGroup.nodes[startNodeIdx].x, nodeGroup.nodes[startNodeIdx].y);
        blipControl = Instantiate(blipPrefab, startPosition, new Quaternion(0,0,0,0)) as BlipControl;
        camera.transform.parent = blipControl.transform;
        camera.transform.localPosition = new Vector3(0, 0, camera.transform.localPosition.z);
    }

    /**
     * Return a copy of the node connections.
     **/
    public bool[,] GetNodeConnection() {
        return nodeConnection.GetNodeConnections();
    }

    public void SetGamePaused(bool pause) {
        isGamePaused = pause;

        if (pause) {
            Time.timeScale = 0;
            joystick.GetComponentInParent<Canvas>().enabled = false;
        } else {
            Time.timeScale = 1;
            joystick.GetComponentInParent<Canvas>().enabled = true;
        }
    }

    public bool IsGamePaused() {
        return isGamePaused;
    }

    /**
     * Disable all player movements
     **/
    public void SetGameWon(bool isBlip) {
        Destroy(joystick.gameObject); // Disable blip movement
        Debug.Log("is Blip won?" + isBlip);
    }
}
