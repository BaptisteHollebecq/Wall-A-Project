using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallA : MonoBehaviour
{
    public PathMaster path;
    public float movementSpeed = 1;

    [HideInInspector] public List<Transform> way = new List<Transform>();
    [HideInInspector] public GameObject currentNode;
    [HideInInspector] public GameObject targetNode;
    [HideInInspector] public int index = 1;
    [HideInInspector] public int graines = 0;
    [HideInInspector] public List<graines> inventory = new List<graines>();
    
    private void Start()
    {
        GetNextNode();
    }

    void GetNextNode()
    {
        if (index > way.Count - 1)
        {
            index = 0;
            targetNode = path.transform.GetChild(0).gameObject;
            index++;
        }
        else if (index == 1)
        {
            path.CalculPath(currentNode);
            targetNode = way[index].gameObject;
            index++;
        }
        else
        {
            targetNode = way[index].gameObject;
            index++;
        }
        StartCoroutine(MoveToNextNode());
    }

    IEnumerator MoveToNextNode()
    {
        //StartCoroutine(RotateTowards());
        var initPos = transform.position;
       

        for (float f = 0; f < 1; f += Time.deltaTime / movementSpeed)
        {
            transform.position = Vector3.Lerp(initPos, targetNode.transform.position, f);
            //m_Transform.rotation = Quaternion.Lerp(initRot, _lookAtPivot.rotation, lerp);
            yield return null;
        }

        transform.position = targetNode.transform.position;
        // m_Transform.rotation = _lookAtPivot.rotation;

        currentNode = targetNode;
       // Debug.Log(currentNode);

        GetNextNode();
    }

  /*  IEnumerator RotateTowards()
    {
        var initRot = transform.rotation;

        for (float f = 0; f < 1; f += Time.deltaTime / movementSpeed)
        {
            var targetRot = Quaternion.LookRotation(targetNode.transform.position - transform.position);
            transform.rotation = Quaternion.Lerp(initRot, targetRot, f);
            yield return null;
        }

        transform.rotation = targetRot;

    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Wall")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
