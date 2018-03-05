using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[System.Serializable]
public class Node {

    public int row = 0;
    public int col = 0;
    public bool isStartNode;
    public bool isGoalNode;

    [SerializeField]
    string connections;

	public int X {
        get { return col * 2; }
    }

    public int Y {
        get { return row * -2; }
    }

    public Vector2 Position {
        get {
            return new Vector2(X, Y);
        }
    }

    public int[] Connections {
        get {
            connections = connections.Replace(" ", "");
            string[] connectionsStrArr = connections.Split(',');

            return Array.ConvertAll(connectionsStrArr, s => int.Parse(s));
        }
    }
}
