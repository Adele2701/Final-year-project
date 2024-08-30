using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangingScene : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Collection()
    {
        SceneManager.LoadScene("Collection");
    }

    public void Pet()
    {
        SceneManager.LoadScene("Model1");
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }
    
    public void Level2() {
        SceneManager.LoadScene("Level2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void SunBear()
    {
        SceneManager.LoadScene("Model");
    }

    public void Login()
    {
        SceneManager.LoadScene("Login");
    }
}
