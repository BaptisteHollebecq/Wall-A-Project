using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarPathFinding
{
    /// <summary>
    /// Return the Distance between two node
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    static public float NodeDistance(Node a, Node b)
    {
        return Vector3.Distance(a.pos, b.pos);
    }


    /// <summary>
    /// Find the best path form start to goal in the grid of nodes
    /// </summary>
    /// <param name="grid"></param>
    /// <param name="start"></param>
    /// <param name="goal"></param>
    public AStarPathFinding(Dictionary<GameObject, Node> grid, Node start, Node goal)
    {
        bool hasFound = false;
        var Queue = new PriorityQueue<Node>();

        Queue.Enqueue(start, 0);

        start.costToHere = 0;
        start.CameFrom = start;

        int i = 0;

        while(Queue.Count > 0 && i < grid.Count)
        {
            Node current = Queue.Dequeue();

            if (current.Equals(goal))
            {
                hasFound = true;
                break;
            }
            foreach (GameObject next in current.neighbors)
            {
                float newCost = current.costToHere + (NodeDistance(current, grid[next]) * grid[next].cost);

                if (!grid[next].check || grid[next].costToHere > newCost)
                {
                    grid[next].costToHere = newCost;

                    grid[next].check = true;

                    double priority = newCost + NodeDistance(goal, grid[next]);

                    Queue.Enqueue(grid[next], priority);

                    grid[next].CameFrom = current;
                }
            }
            i++;
        }
        if (i == grid.Count)
            Debug.LogWarning("Error : AstartPathFinding infinite loop");
        if (hasFound == false)
            Debug.LogWarning("Error : AstartPathFinding can't find a path");

    }

}
