using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMouse : MonoBehaviour
{
    public float sensibilidad = 300f;
    private Vector2 entradaAngulos;
    private Vector2 angulos;

    public Vector2 limitesCamara;


    void Update()
    {
        entradaAngulos = new Vector2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));

        angulos.x -= entradaAngulos.x * sensibilidad;
        angulos.y += entradaAngulos.y * sensibilidad;

        angulos.x = Mathf.Clamp(angulos.x, limitesCamara.x, limitesCamara.y);

        transform.localRotation = Quaternion.Euler(angulos.x, angulos.y, 0f);   
    }
}
