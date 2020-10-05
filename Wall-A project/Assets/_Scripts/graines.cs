using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum state { dispo, took, planted, wait}
public class graines : MonoBehaviour
{
    public int waitingTime = 10;
    bool dispo = true;

    public state currentState = state.dispo;

    public MeshFilter mesh;
    public Mesh avecGraines;
    public Mesh sansGraines;

    private void Update()
    {
        if (currentState == state.planted)
        {
            StartCoroutine(Wait());
            currentState = state.wait;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitingTime);
        dispo = true;
        currentState = state.dispo;
        mesh.mesh = avecGraines;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WallA")
        {

            if (dispo)
            {
                dispo = false;
                currentState = state.took;
                mesh.mesh = sansGraines;
                other.GetComponent<WallA>().graines += 1;
                Debug.Log(other.GetComponent<WallA>().graines);
                other.GetComponent<WallA>().inventory.Add(this);
            }
        }
    }
}
