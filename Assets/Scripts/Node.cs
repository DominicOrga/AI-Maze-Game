using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Node {

    public int row = 0;
    public int col = 0;
    public bool isStartNode;
    public bool isGoalNode;

	public int x {
        get { return col * 2; }
    }

    public int y {
        get { return row * -2; }
    }

    public Vector2 Position {
        get {
            return new Vector2(x, y);
        }
    }
}
