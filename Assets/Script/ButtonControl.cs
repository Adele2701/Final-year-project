using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{ 
    public void show(GameObject obj) // Cannot touch use in many
    {
        if (obj.activeSelf != true)
        {
            obj.SetActive(true);
        }

        else 
        {
            obj.SetActive(false);
        }
    }

}
