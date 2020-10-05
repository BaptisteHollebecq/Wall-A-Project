using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Canvas buttonCanvas;
    public Canvas creditCanvas;
    public Canvas LevelCanvas;

    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Lunch(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Credit()
    {
        buttonCanvas.gameObject.SetActive(false);
        creditCanvas.gameObject.SetActive(true);
    }

    public void Level()
    {
        buttonCanvas.gameObject.SetActive(false);
        LevelCanvas.gameObject.SetActive(true);
    }

    public void BackCredit()
    {
        buttonCanvas.gameObject.SetActive(true);
        creditCanvas.gameObject.SetActive(false);
    }

    public void BackLevel()
    {
        buttonCanvas.gameObject.SetActive(true);
        LevelCanvas.gameObject.SetActive(false);
    }


}
