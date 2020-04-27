using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ship;


public class LivesScript : MonoBehaviour
{
    public int LivesValue;

    Text Lives;

    

    void Start()
    {
        Lives = GetComponent<Text>();
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
