using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobControl : MonoBehaviour {

    bool[,] nodeConnections;
    LevelManager levelManager;

    float speed = 2f;
    Rigidbody2D rigidBody;

    bool isMove;
    Node currentNode;
    Node destinationNode;

    void Awake() {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
        nodeConnections = levelManager.NodeConnections;

        StartCoroutine(Search(0));
	}

	// Update is called once per frame
	void Update () {

        if (isMove) {
            float deltaX = transform.position.x - destinationNode.x;
            float deltaY = transform.position.y - destinationNode.y;

            if (Mathf.Abs(deltaX) < 0.5f && Mathf.Abs(deltaY) < 0.5f) {
                isMove = false;
            }
            else {
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, destinationNode.Position, step);

                int rnd = Random.Range(10, 20);
                Vector2 force = Vector2.zero;
                if (currentNode.row == destinationNode.row) {
                    force.y += deltaY > 0 ? -rnd : rnd;
                } else {
                    force.x += deltaX > 0 ? -rnd : rnd;
                }
                //rigidBody.AddForce(force);
            }
        }
	}

    void ApplyForwardCheck(int nodeIdx) {
        for (int i = 0, s = nodeConnections.GetLength(0); i < s; i++) {
            nodeConnections[i, nodeIdx] = false;
        }
    }

    void ReverseForwardCheck(int nodeIdx) {
        bool[,] nodeConnections_temp = levelManager.NodeConnections;

        for (int i = 0, s = nodeConnections.GetLength(0); i < s; i++) {
            nodeConnections[i, nodeIdx] = nodeConnections_temp[i, nodeIdx];
        }
    }

    WaitUntil MoveToNode(int nodeIdx) {
        destinationNode = levelManager.NodeGroup[nodeIdx];
        isMove = true;

        return new WaitUntil(() => !isMove);
    }

    int[] GetAllConnectedNodes(int nodeIdx) {
        List<int> connectedNodes = new List<int>();

        for (int j = 0, s = nodeConnections.GetLength(1); j < s; j++) {
            if (nodeConnections[nodeIdx, j]) {
                connectedNodes.Add(j);
            }
        }

        return connectedNodes.ToArray();
    }

    void ShuffleArray(int[] array) {
        for (int i = 0, s = array.GetLength(0); i < s; i++) {
            int rnd = Random.Range(0, s);

            int temp = array[i];
            array[i] = array[rnd];
            array[rnd] = temp;
        }
    }

    /**
     * Backtrack search through recursive coroutine.
     **/
    IEnumerator Search(int nodeIdx) {
        currentNode = levelManager.NodeGroup[nodeIdx];
        ApplyForwardCheck(nodeIdx);

        int[] connectedNodes = GetAllConnectedNodes(nodeIdx);

        if (connectedNodes.GetLength(0) == 0)
            yield return false;

        ShuffleArray(connectedNodes);

        for (int i = 0, s = connectedNodes.GetLength(0); i < s; i++) {
            int destinationNodeIdx = connectedNodes[i];

            yield return MoveToNode(destinationNodeIdx);

            yield return StartCoroutine(Search(destinationNodeIdx));

            yield return MoveToNode(nodeIdx);

            ReverseForwardCheck(destinationNodeIdx);
        }

        yield return false;
    }

    public void StartSearch(int startNodeIdx) {
        StartCoroutine(Search(startNodeIdx));
    }
}
