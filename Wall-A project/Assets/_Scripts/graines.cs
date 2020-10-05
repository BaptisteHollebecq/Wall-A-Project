using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum state { dispo, took, planted, wait}
public class graines : MonoBehaviour
{
    public int waitingTime = 10;
    bool dispo = true;

    public state currentState = state.dispo;

    public Transform avecGraines;
    public Transform sansGraines;

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
        avecGraines.gameObject.SetActive(true);
        sansGraines.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WallA")
        {

            if (dispo)
            {
                dispo = false;
                currentState = state.took;
                avecGraines.gameObject.SetActive(false);
                sansGraines.gameObject.SetActive(true);
                other.GetComponent<WallA>().graines += 1;
                Debug.Log(other.GetComponent<WallA>().graines);
                other.GetComponent<WallA>().inventory.Add(this);
            }
        }
    }
}
