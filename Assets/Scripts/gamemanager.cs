using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("Gold", 500);
        PlayerPrefs.SetInt("Lumber", 100);
        PlayerPrefs.SetInt("Food", 100);
    }
}
