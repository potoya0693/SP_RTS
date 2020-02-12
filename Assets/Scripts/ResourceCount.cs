using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTS;

public class ResourceCount : MonoBehaviour
{
      public string key;

        public Text textLabel;

        // Update is called once per frame
        void Update()
        {
            textLabel.text = PlayerPrefs.GetInt(key, 0).ToString();
        }
}
