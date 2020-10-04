using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Canvas buttonCanvas;
    public Canvas creditCanvas;

    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Credit()
    {
        buttonCanvas.gameObject.SetActive(false);
        creditCanvas.gameObject.SetActive(true);
    }

    public void Back()
    {
        buttonCanvas.gameObject.SetActive(true);
        creditCanvas.gameObject.SetActive(false);
    }
}
