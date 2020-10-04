using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Node
{
    public GameObject worldObject;
    public Vector3 pos;
    public float cost;
    public float costToHere;
    public List<GameObject> neighbors;
    public Node CameFrom;
    public bool check;
    
    public Node(GameObject obj)
    {
        worldObject = obj;
        pos = obj.transform.position;
        cost = GetCost(obj);                   
        costToHere = 0;
        neighbors = GetNeighbors(obj);
        CameFrom = null;
        check = false;
    }

    /// <summary>
    /// return a multiplier of the node depending on the tag it has
    /// </summary>
    float GetCost(GameObject obj)
    {
        switch (obj.tag)
        {
            case "Water":
                {
                    return PathMaster.WaterCost;
                }
            case "Forest":
                {
                    return PathMaster.ForestCost;
                }
            default:
                {
                    return 1;
                }
        }
    }


    /// <summary>
    /// Return a list<Transform> of all neighbors with the pathMaster settings
    /// </summary>
    /// <param name="nodeGameObject"></param>
    /// <returns></returns>
    List<GameObject> GetNeighbors(GameObject obj)
    {
        List<GameObject> next = new List<GameObject>();

        int layerMask = 1 << 9 | 1 << 10;
        //layerMask = ~layerMask;

        Collider[] access = Physics.OverlapSphere(obj.transform.position, PathMaster.radius, PathMaster.whatIsNode);
        if (access.Length == 0)
            return null;
        foreach(Collider c in access)
        {
            if (Vector3.Distance(c.transform.position, obj.transform.position) < 1)
                continue;
            RaycastHit hit;
            if (Physics.Raycast(obj.transform.position, c.transform.position - obj.transform.position, out hit, layerMask) && hit.transform == c.transform)
                next.Add(c.gameObject);
        }
        return next;
    }
}
