using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HcerDaño : MonoBehaviour
{
    public float cantidadDaño;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && other.GetComponent<CodigoSalud>())
        {
            other.GetComponent<CodigoSalud>().recibirDaño(cantidadDaño);
        }
    }
}
