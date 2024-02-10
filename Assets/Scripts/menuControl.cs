using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuControl : MonoBehaviour
{
    
   public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayGameAfterEnd()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -4);

    }

    public void PlayGameLevel1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void PlayGameLevel2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void PlayGameLevel3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -2);

    }
    public void PlayGameLevel4()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -3);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
