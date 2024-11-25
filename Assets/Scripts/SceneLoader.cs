using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void loadLevel()
    {
        //Load Game
        SceneManager.LoadSceneAsync("Game");
    }

    public void loadMenu()
    {
        //Load Menu
        SceneManager.LoadSceneAsync("Menu");
    }

    //restart game (called by button)
    public void RestartGame()
    {
        //Reset time and reload scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;

    }

    public void QuitGame()
    {
        //Reset time and quit app
        Time.timeScale = 1;
        Application.Quit();
    }
}