using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Score
{
    public class ScoreScript : MonoBehaviour
    {

        public static int ScoreValue;

        Text Score;

        void Start()
        {
            ScoreValue = 0;
            Score = GetComponent<Text>();
        }


        void Update()
        {
            Score.text = "SCORE: " + ScoreValue;
        }
    }
}
