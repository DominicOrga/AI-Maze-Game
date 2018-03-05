using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGroup : MonoBehaviour {
    public Node[] nodes;

    public int[] StartNodes {
        get {
            List<int> startNodes = new List<int>();

            for (int i = 0, s = nodes.GetLength(0); i < s; i++) {
                if (nodes[i].isStartNode) {
                    startNodes.Add(i);
                }
            }
            return startNodes.ToArray();
        }
    }

    public int[] GoalNodes {
        get {
            List<int> goalNodes = new List<int>();

            for (int i = 0, s = nodes.GetLength(0); i < s; i++) {
                if (nodes[i].isGoalNode) {
                    goalNodes.Add(i);
                }
            }
            return goalNodes.ToArray();
        }
    }

    public int RandomizeStartNodeIdx(int goalNodeIdx = -1) {
        int[] startNodes = this.StartNodes;

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
        int[] goalNodes = this.GoalNodes;

        for (int i = 0; i < 25; i++) {
            int rnd = Random.Range(0, goalNodes.Length);
            int goalNodeIdx = goalNodes[rnd];

            if (goalNodeIdx != startNodeIdx)
                return goalNodeIdx;
        }

        Debug.Log("Start and Goal Node are the same!");
        return -1;
    }

    public bool[,] NodeConnections {
        get {
            bool[,] nodeConnections = new bool[nodes.Length, nodes.Length];

            for (int i = 0, s = nodes.Length; i < s; i++) {
                Node node = nodes[i];

                for (int j = 0, t = node.Connections.Length; j < t; j++) {
                    nodeConnections[i, node.Connections[j]] = true;
                }
            }

            return nodeConnections;
        }
    }

}
