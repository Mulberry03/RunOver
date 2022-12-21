using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Validador : MonoBehaviour
{
    public GameObject textoFlotantePrefab;
    public Text CajaNombre, CajaEdad;
    string Nombre;
    byte Edad;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Validar(){
        //SOLO SI ES MAYOR DE EDAD
        Nombre= CajaNombre.text;
        Edad= byte.Parse(CajaEdad.text);
        Debug.Log(Nombre);
        Debug.Log(Edad);
        if (Edad>=18){

            SceneManager.LoadScene("Nivel 1");
        }
        if(Edad < 18){
            if(textoFlotantePrefab)
            {
                MostrarTexto();
            }
            
        }
    }

    public void MostrarTexto()
    {
        GameObject texto = Instantiate(textoFlotantePrefab);
    }
}
