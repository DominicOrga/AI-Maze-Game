/*
 * Arthur Cousseau, 2017
 * https://www.linkedin.com/in/arthurcousseau/
 * Please share this if you enjoy it! :)
*/

using UnityEngine;

public class NodeConnections : MonoBehaviour {

    [System.Serializable]
    public class CellRow {
        public bool[] row = new bool[defaultGridSize];
    }

    private const int defaultGridSize = 3;

    [Range(1, 99)]
    public int gridSize = defaultGridSize;

    public CellRow[] cells = new CellRow[defaultGridSize];

    private bool[,] nodeConnections = new bool[defaultGridSize, defaultGridSize];

    public bool[,] GetNodeConnections() {
        
        bool[,] ret = new bool[gridSize, gridSize];

        for (int i = 0; i < gridSize; i++) {
            for (int j = 0; j < gridSize; j++) {
                ret[i, j] = cells[i].row[j];
            }
        }

        return ret;
    }
}
