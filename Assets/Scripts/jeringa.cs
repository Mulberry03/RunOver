using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jeringa : MonoBehaviour
{
    public GameObject ValorPuntos;
    public float Puntitos;
    private void OntriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ValorPuntos.GetComponent<Puntos>().puntos += Puntitos;
            Destroy(gameObject);
        }
        
    }

}
