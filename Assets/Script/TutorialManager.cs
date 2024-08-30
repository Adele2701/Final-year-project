using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    private void Awake() //Before onclick
    {
        if (!PlayerPrefs.HasKey("first_time") || PlayerPrefs.GetInt("first_time") != 8)
        {
            // First run logic goes here
            Debug.Log("First run after download!");

            PlayerPrefs.SetInt("first_time", 8);
            PlayerPrefs.Save();

        }
        else // if(PlayerPrefs.GetInt("first_time") == 8)
        {
            Debug.Log("Application has been run before.");

            SceneManager.LoadScene("Login");
        }
    }

}
