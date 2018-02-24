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
}
