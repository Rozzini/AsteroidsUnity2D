using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;

public class ScoreManeger : MonoBehaviour
{

    private string url = "https://localhost:44333/api/Models";


    public RectTransform prefab;
    public RectTransform content;
    private List<Player> playersList = new List<Player>();
    void Start()
    {
        StartCoroutine(GetRequest(url));
    }

    void Update()
    {

    }

    public void GetText()
    {
        int x = 0;
        int y = 0;
        for(int i = 0; i < playersList.Count; i++)
        {
            //CreateText(playersList[i]);
            y -= 20;
            x -= 1;
        }
    }

    public void CreateText(/*Transform canvas_transform, float x, float y, Player player, int font_size, int iterator*/)
    {

        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        foreach(Player p in playersList)
        {
            var instance = GameObject.Instantiate(prefab.gameObject) as GameObject;
            instance.transform.SetParent(content, false);
            string textToPrint = p.PlayerName + "    " + p.Score;
            Text text = instance.GetComponent<Text>();

            text.text = textToPrint;
            text.fontSize = 15;
            text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            text.color = Color.white;
        }
        //string textToPrint = player.PlayerName + "    " + player.Score;
        //Instantiate(TextBox, gameObject.transform.position, Quaternion.identity);
        //Text text = TextBox.GetComponent<Text>();
        //text.text = textToPrint;
        //text.fontSize = 15;
        //text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        //text.color = Color.white;

        //string BoxName = "Score" + iterator + 1;
        //string textToPrint = player.PlayerName + "    " + player.Score;

        //GameObject UItextGO = new GameObject(BoxName);
        //UItextGO.transform.SetParent(canvas_transform);

        //RectTransform trans = UItextGO.AddComponent<RectTransform>();
        //trans.anchoredPosition = new Vector2(x, y);

        //Text text = UItextGO.AddComponent<Text>();
        //text.text = textToPrint;
        //text.fontSize = font_size;
        //text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        //text.color = Color.white;

        //return UItextGO;
    }

    IEnumerator GetRequest(string url)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                
                Player[] players = JsonConvert.DeserializeObject<Player[]>(www.downloadHandler.text);

                for( int i = 0; i < players.Length; i++)
                {
                    playersList.Add(players[i]);
                    Debug.Log(players[i].PlayerName);
                    Debug.Log(players[i].Score);
                }

            }
        }
        CreateText();
    }
}