using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    private void OncollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
