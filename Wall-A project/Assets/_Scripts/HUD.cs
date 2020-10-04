using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text txt;
    public WallA walla;

    private void Update()
    {
        txt.text = walla.graines.ToString();
    }
}
