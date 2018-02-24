using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGroup : MonoBehaviour {
    public List<Node> nodes;

    public int[] startNodes {
        get {
            List<int> startNodes = new List<int>();

            for (int i = 0; i < nodes.Count; i++) {
                if (nodes[i].isStartNode) {
                    startNodes.Add(i);
                }
            }
            return startNodes.ToArray();
        }
    }

    public int[] goalNodes {
        get {
            List<int> goalNodes = new List<int>();

            for (int i = 0; i < nodes.Count; i++) {
                if (nodes[i].isGoalNode) {
                    goalNodes.Add(i);
                }
            }
            return goalNodes.ToArray();
        }
    }

    public int RandomizeStartNodeIdx(int goalNodeIdx = -1) {
        int[] startNodes = this.startNodes;

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
        int[] goalNodes = this.goalNodes;

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
