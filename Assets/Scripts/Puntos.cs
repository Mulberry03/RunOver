using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntos : MonoBehaviour
{
    public float puntos;
    public Text textoPuntos;
    // Update is called once per frame
    void Update()
    {
        textoPuntos.text = "Puntos :" + puntos.ToString();
        if(puntos <0)
        {
            puntos = 0;
        }
        
    }
}
