using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ship;
using UnityEngine.Networking;


public class Playerr
{
    public string PlayerName;

    public int Score;
}

public class LivesScript : MonoBehaviour
{
    public int LivesValue;

    Text Lives;

    

    void Start()
    {
        Playerr player = new Playerr();
        player.PlayerName = "aaaa";
        player.Score = 123;
        string json = JsonUtility.ToJson(player);
        StartCoroutine(PostRequest("https://localhost:44333/api/Models", json));
        Lives = GetComponent<Text>();
    }

    IEnumerator PostRequest(string url, string json)
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
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }

    void Update()
    {
        LivesValue = RocketControll.ShipArmor;
        if (LivesValue == 0)
        {
            Lives.text = "YOU ALMOST DEAD";
        }
        else if(LivesValue < 0)
        {
            Lives.text = "WASTED";
        }
        else
        {
            Lives.text = "ARMOR: " + LivesValue;
        }
    }
}
