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
    public BlipControl blipPrefab;
    //public Rigidbody2D blobPrefab;

    NodeGroup nodeGroup;
    NodeConnection nodeConnection;

    BlipControl blipControl;


    // Use this for initialization
    void Start() {
        nodeGroup = gameObject.GetComponent<NodeGroup>();
        nodeConnection = gameObject.GetComponent<NodeConnection>();

        int startNodeIdx = RandomizeStartNodeIdx();
        int goalNodeIdx = RandomizeGoalNodeIdx(startNodeIdx);

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

    public int RandomizeStartNodeIdx(int goalNodeIdx = -1) {
        int[] startNodes = nodeGroup.startNodes;

        for (int i = 0; i < 25; i++) {
            int rnd = Random.Range(0, startNodes.Length);
            int startNodeIdx = startNodes[rnd];

            if (goalNodeIdx != startNodeIdx)
                return startNodeIdx;
        }

        Debug.Log("Start and Goal Node are the same!");
        return -1;
    }

    public int RandomizeGoalNodeIdx(int startNodeIdx = -1) {
        int[] goalNodes = nodeGroup.goalNodes;
        
        for (int i = 0; i < 25; i++) {
            int rnd = Random.Range(0, goalNodes.Length);
            int goalNodeIdx = goalNodes[rnd];

            if (goalNodeIdx != startNodeIdx)
                return goalNodeIdx;
        }

        Debug.Log("Start and Goal Node are the same!");
        return -1;
    }
}
