using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public PathMaster path;
    public GameObject Wall;
    public int decayTime = 10;
    bool isGrown = false;

    GameObject wallInstance;

    private void OnMouseDown()
    {
        if (!isGrown && path.walla.graines != 0)
            Grow();
    }

    public void Grow()
    {
        path.walla.graines -= 1;
        path.walla.inventory[0].currentState = state.planted;
        path.walla.inventory.RemoveAt(0);
        isGrown = true;
        wallInstance = Instantiate(Wall, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), Quaternion.identity);

        StartCoroutine(Decay());
        if (path.walla.index != path.walla.way.Count)
            path.walla.index = 1;
    }

    IEnumerator Decay()
    {
        yield return new WaitForSeconds(decayTime);
        isGrown = false;
        //reviens a l'etat normale
        Destroy(wallInstance);
        wallInstance = null;
    }

}
