using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public Camera camera;
    public RectTransform joystick;
    public LevelAnimator levelAnimator;
    public GameObject blipPrefab;
    public GameObject blobPrefab;

    NodeGroup nodeGroup;
    NodeConnections nodeConnection;

    BlipControl blipControl;
    BlobControl[] blobControls;

    bool isGamePaused;

    void Awake() {
        isGamePaused = false;
        nodeGroup = gameObject.GetComponent<NodeGroup>();
        nodeConnection = gameObject.GetComponent<NodeConnections>();
        joystick.GetComponentInParent<Canvas>().enabled = false;
    }

    // Use this for initialization
    void Start() {
        int startNodeIdx = nodeGroup.RandomizeStartNodeIdx();
        int goalNodeIdx = nodeGroup.RandomizeGoalNodeIdx(startNodeIdx);

        Vector2 startPosition = new Vector2(nodeGroup.nodes[startNodeIdx].x, nodeGroup.nodes[startNodeIdx].y);
        blipControl = Instantiate(blipPrefab, startPosition, new Quaternion(0,0,0,0)).GetComponent<BlipControl>();
        camera.transform.parent = blipControl.transform;
        camera.transform.localPosition = new Vector3(0, 0, camera.transform.localPosition.z);

        blobControls = new BlobControl[3];
        for (int i = 0; i < blobControls.Length; i++) {
            blobControls[i] = Instantiate(blobPrefab, startPosition, new Quaternion(0, 0, 0, 0)).GetComponent<BlobControl>();
        }

        levelAnimator.PlayStartGame(startNodeIdx);
    }

    public void startGame(int startNodeIdx) {
        joystick.GetComponentInParent<Canvas>().enabled = true;

        for (int i = 0; i < blobControls.Length; i++) {
            blobControls[i].StartSearch(startNodeIdx);
        }
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

    /**
     * Disable all player movements
     **/
    public void SetGameWon(bool isBlip) {
        levelAnimator.StartEndGame(isBlip);
        Destroy(joystick.gameObject); // Disable blip movement
    }

    public void GoHome() {
        SceneManager.LoadScene(sceneName: "MenuScene");
    }
}
