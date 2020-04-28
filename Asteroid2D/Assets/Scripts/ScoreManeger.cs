using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ScoreManeger : MonoBehaviour
{

    private string url = "https://localhost:44333/api/Models";

    void Start()
    {
        GetText(url);
        //CreateText(transform.gameObject.transform, 0, 0, "asdasd", 15);
        //StartCoroutine(GetScores(url));
    }

    void Update()
    {

    }

    public void GetText(string url)
    {
        IEnumerator enumerator = GetRequest(url);
        int x = 0;
        int y = 0;
        while (enumerator.MoveNext())
        {
            object item = enumerator.Current;
            Player json = JsonUtility.FromJson<Player>(item);
            string a = "" + json.PlayerName + "   " + json.Score;
            CreateText(transform.gameObject.transform, x, y, a, 15);
            y++;
        }
    }

    GameObject CreateText(Transform canvas_transform, float x, float y, string text_to_print, int font_size)
    {
        GameObject UItextGO = new GameObject("Text2");
        UItextGO.transform.SetParent(canvas_transform);

        RectTransform trans = UItextGO.AddComponent<RectTransform>();
        trans.anchoredPosition = new Vector2(x, y);

        Text text = UItextGO.AddComponent<Text>();
        text.text = text_to_print;
        text.fontSize = font_size;
        text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        text.color = Color.white;

        return UItextGO;
    }


    IEnumerator GetRequest(string uri)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
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
}
