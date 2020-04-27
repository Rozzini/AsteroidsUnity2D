using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataSenderScript : MonoBehaviour
{
    public InputField inputField;

    string inputText;


    void Start()
    {
        inputText = PlayerPrefs.GetString("aaaaaa");
        inputField.text = inputText;
    }

    public void saveData()
    {
        inputText = inputField.text;
        PlayerPrefs.SetString("aaaaaa", inputText);
    }
    

    
}
