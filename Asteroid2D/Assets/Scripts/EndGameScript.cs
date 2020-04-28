using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ship;
using Score;
using UnityEngine.SceneManagement;
using System.Data;
using UnityEngine.UI;

public class EndGameScript : MonoBehaviour
{

    public InputField inputField;

    string inputText;

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
   
    public void Restart()
    {
        SceneManager.LoadScene("Game"); 
    }

   public void saveData()
    {
        inputText = inputField.text;
    }

}
