using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
    public void SecondLevel()
    {
        SceneManager.LoadScene(2);
    
    }
    public void ThirdLevel()
    {
        SceneManager.LoadScene(3);
    }
    public void ForthLevel()
    {
        SceneManager.LoadScene(4);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
