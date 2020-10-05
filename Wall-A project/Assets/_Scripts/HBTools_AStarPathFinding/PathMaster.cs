using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMaster : MonoBehaviour
{
    /// <summary>
    /// HBTools AstarPathFinding 
    /// You only need to put that script on the parent of all the nodes and that's it
    /// the start node is the first child and the goal node is the last child
    /// (be sure that all childs have the same layer and to set it in the inspector)
    /// </summary>

    public WallA walla;

    [Header("Settings")]
    /// Max lenght between a node and it neighbors
    public float edgesLenght;

    /// Layer to be sure to only get nodes
    public LayerMask nodeLayer;
    public LayerMask WallALayer;

    /// Multiplier of cost if node is considered as water
    public int waterCostMulti = 1;

    /// Multiplier of cost if node is considered as forest
    public int forestCostMulti = 1;

    /// Check it to Debug.DrawRay the path
    public bool DrawPathDebug;

    #region staticVariables

    /// Set up in the GetGrid Methode

    public static float radius;
    public static LayerMask whatIsNode;
    public static LayerMask whatIsWallA;
    public static int WaterCost;
    public static int ForestCost;

    #endregion

    /// List of all gameobject and their associated node
    public Dictionary<GameObject, Node> _grid;
    public Node start;
    public Node goal;

    [HideInInspector] public List<Transform> goodPath = new List<Transform>();
    [HideInInspector] public Transform nextNode;
    [HideInInspector] public float totalLength;

    private void Awake()
    {
        _grid = new Dictionary<GameObject, Node>();
        foreach (Transform t in transform)
        {
            _grid.Add(t.gameObject, new Node(t.gameObject));
        }
        walla.currentNode = transform.GetChild(0).gameObject;

        CalculPath(walla.currentNode);
    }

    private void Start()
    {

    }

    private void Update()
    {
        
    }

    public void CalculPath(GameObject run)
    {
        /// Fill the _grid with all the childs and their node
        /// 
        GetGrid(run);
        ///

        /// Find the path in the grid
        /// 
        var path = new AStarPathFinding(_grid, start, goal);
        ///

        /// Fill the goodPath List with only the Transform of all the nodes that are in the best path
        /// 
        RetracePath(goal, start);
        ///

        if (DrawPathDebug)
            DrawPath();
    }

    public void GetGrid(GameObject run)
    {
        radius = edgesLenght;
        whatIsNode = nodeLayer;
        WaterCost = waterCostMulti;
        ForestCost = forestCostMulti;

        _grid = new Dictionary<GameObject, Node>();
        foreach (Transform t in transform)
        {
            _grid.Add(t.gameObject, new Node(t.gameObject));
        }
        start = _grid[run];
        goal = _grid[transform.GetChild(transform.childCount - 1).gameObject];
    }


    void RetracePath(Node goal, Node start)
    {
        Node g = goal;
        goodPath = new List<Transform>();
        totalLength = 0;
        int i = 0;
        while (g != start && i < _grid.Count)
        {
            goodPath.Add(g.worldObject.transform);
            totalLength += Vector3.Distance(g.worldObject.transform.position, g.CameFrom.worldObject.transform.position);
            g = g.CameFrom;
            i++;
        }
        if (i == _grid.Count)
            Debug.LogWarning("Error : failed to trace back the path");
        goodPath.Add(start.worldObject.transform);
        goodPath.Reverse();
        if (goodPath.Count > 1)
            nextNode = goodPath[1];
        else
            nextNode = transform.GetChild(0).transform;
        walla.way = goodPath;
    }

    void DrawPath()
    {
        for (int i = 0; i < goodPath.Count-1; i++)
        {
            Debug.DrawRay(goodPath[i].position, goodPath[i + 1].position - goodPath[i].position, Color.green, 1f);
            GetComponent<LineRenderer>().positionCount = goodPath.Count - 1;
            GetComponent<LineRenderer>().SetPosition(i, goodPath[i].position);
        }
    }
}
