using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodigoSalud : MonoBehaviour
{

    public float salud = 100;
    public float saludMax = 100;

    public Image barraSalud;


    void Actualizar()
    {
        barraSalud.fillAmount = salud / saludMax;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Actualizar();
    }

    public void recibirDaño(float daño)
    {
        salud -= daño;
    }
}
