using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Score;
using System;

public class DataSenderScript : MonoBehaviour
{
    public InputField inputField;

    public GameObject Field;

    public GameObject SubmitButton;

    public GameObject SubmitionTetx;

    public GameObject TryAgain;

    string inputText;

    string url = "https://localhost:44333/Scores/PostScore";

    void Start()
    {
        Field.SetActive(true);
        SubmitButton.SetActive(true);
        SubmitionTetx.SetActive(false);
        TryAgain.SetActive(false);
        inputField.text = "";
    }

    public void saveData()
    {
        inputText = inputField.text;
        Player player = new Player();
        player.PlayerName = inputText;
        player.Score = ScoreScript.ScoreValue;
        string json = JsonUtility.ToJson(player);
        StartCoroutine(PostRequest(json));
    }

    IEnumerator PostRequest(string json)
    {
        var uwr = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
            TryAgain.SetActive(true);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
            Field.SetActive(false);
            SubmitButton.SetActive(false);
            SubmitionTetx.SetActive(true);
            TryAgain.SetActive(false);
        }
    }

}

[Serializable]
public class Player
{
    public string PlayerName;

    public int Score;
}

