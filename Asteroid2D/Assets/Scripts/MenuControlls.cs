using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControlls : MonoBehaviour
{

    public GameObject Menu;
    public GameObject ScoreBoard;
    public void PlayPressed()
    {
        SceneManager.LoadScene("Game");
    }

    public void ScorePressed()
    {
        Menu.SetActive(false);
        ScoreBoard.SetActive(true);
    }

    public void MenuFromScorePressed()
    {
        Menu.SetActive(true);
        ScoreBoard.SetActive(false);
    }
}
