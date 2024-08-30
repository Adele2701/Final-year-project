using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using System;

public class Login : MonoBehaviour
{
    public GameObject loginButton;
    Guid currentDeviceID;
    int count = 0;

    public void Start()
    {
        if (PlayerPrefs.GetString("LootLockerGuestPlayerID", "unknown") != currentDeviceID.ToString())
        {
            currentDeviceID = Guid.NewGuid();
        }
    }

    public void GuestLogin()
    {
        if (PlayerPrefs.GetString("LootLockerGuestPlayerID", "unknown") == "unknown")
        {
            LootLockerSDKManager.StartGuestSession(currentDeviceID.ToString(), (response) =>
            {
                if (response.success)
                {
                    Debug.Log("successfully started LootLocker session");
                }
                else
                {
                    Debug.Log("error starting LootLocker session");
                }
            });
        }
        else
        {
            LootLockerSDKManager.StartGuestSession(PlayerPrefs.GetString("LootLockerGuestPlayerID", "unknown"), (response) =>
            {
                if (response.success)
                {
                    Debug.Log("successfully started LootLocker session");
                }
                else
                {
                    Debug.Log("error starting LootLocker session");
                }
            });
        }
    }
}
