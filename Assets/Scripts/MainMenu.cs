using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string playScene;
    public string creditScene;
    public string settingsScene;

    public void Play () {
        SceneManager.LoadScene(playScene);
    }

    public void Credits () {
        SceneManager.LoadScene(creditScene);
    }

    public void Exit () {
        Application.Quit(0);
    }

    public void Settings () {
        SceneManager.LoadScene(settingsScene);
    }

}
