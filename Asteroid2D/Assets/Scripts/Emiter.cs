using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace EmiterSystem
{
    public class Emiter : MonoBehaviour
    {
        public GameObject BigAsteroid;

        public Vector3 InitialCoords;

        float tempTime;

        void Update()
        {
            tempTime += Time.deltaTime;
            if (tempTime > 2)
            {
                tempTime = 0;
                Instantiate(BigAsteroid, InitialCoords, Quaternion.identity);
            }
        }
    }
}
