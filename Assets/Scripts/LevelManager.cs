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
    NodeConnections nodeConnection;

    BlipControl blipControl;

    bool isGamePaused;

    void Awake() {
        isGamePaused = false;
        nodeGroup = gameObject.GetComponent<NodeGroup>();
        nodeConnection = gameObject.GetComponent<NodeConnections>();
    }

    // Use this for initialization
    void Start() {
        int startNodeIdx = nodeGroup.RandomizeStartNodeIdx();
        int goalNodeIdx = nodeGroup.RandomizeGoalNodeIdx(startNodeIdx);

        Vector2 startPosition = new Vector2(nodeGroup.nodes[startNodeIdx].x, nodeGroup.nodes[startNodeIdx].y);
        blipControl = Instantiate(blipPrefab, startPosition, new Quaternion(0,0,0,0)) as BlipControl;
        camera.transform.parent = blipControl.transform;
        camera.transform.localPosition = new Vector3(0, 0, camera.transform.localPosition.z);
    }

    public Node[] NodeGroup {
        get {
            return nodeGroup.nodes;
        }
    }

    /**
     * Return a copy of the node connections.
     **/
    public bool[,] NodeConnections {
        get {
            return nodeConnection.GetNodeConnections();
        }
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
        StopAllCoroutines();
        Debug.Log("is Blip won?" + isBlip);
    }
}
