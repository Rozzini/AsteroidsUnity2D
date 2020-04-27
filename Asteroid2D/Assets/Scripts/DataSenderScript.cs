using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Score;

public class DataSenderScript : MonoBehaviour
{
    public InputField inputField;

    string inputText;


    void Start()
    {
        inputText = PlayerPrefs.GetString("aaaaaa");
        inputField.text = inputText;
    }


    public void SaveData()
    {
        PostCrt();
        //string url = "https://localhost:44333/api/Models";
        inputText = inputField.text;
    }
    IEnumerator PostCrt()
    {
        WWWForm form = new WWWForm();
        form.AddField("PlayerName", "ABC");
        form.AddField("Score", 1234);

        using (UnityWebRequest www = UnityWebRequest.Post("https://localhost:44333/api/Models", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Post Request Complete!");
            }
        }
    }

    //public void saveData()
    //{
    //    string url = "https://localhost:44333/api/Models";
    //    inputText = inputField.text;
    //    Player player = new Player();
    //    player.PlayerName = inputText;
    //    player.Score = ScoreScript.ScoreValue;
    //    string json = JsonUtility.ToJson(player);
    //    Post(url, json);
    //}

    //[System.Obsolete]
    //IEnumerator Post(string url, string bodyJsonString)
    //{
    //    var request = new UnityWebRequest(url, "POST");
    //    byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
    //    request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
    //    request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
    //    request.SetRequestHeader("Content-Type", "application/json");

    //    yield return request.Send();

    //    Debug.Log("Status Code: " + request.responseCode);
    //}

}

public class Player
{
    public string PlayerName;

    public int Score;
}




