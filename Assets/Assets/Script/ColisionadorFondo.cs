using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionadorFondo : MonoBehaviour
{
    private GameObject[] fondos;
    private GameObject[] pisos;

    private float ultimaXFondo;
    private float ultimaXPiso;

    void Awake()
    {
        fondos = GameObject.FindGameObjectsWithTag("fondo");
        pisos = GameObject.FindGameObjectsWithTag("piso");

        ultimaXFondo = fondos[0].transform.position.x;
        ultimaXPiso = pisos[0].transform.position.x;

        for (int i = 0; i < fondos.Length; i++)
        {
            if (ultimaXFondo < fondos[i].transform.position.x)
            {
                ultimaXFondo = fondos[i].transform.position.x;
            }
        }

        for (int i = 0; i < fondos.Length; i++)
        {
            if (ultimaXPiso < pisos[i].transform.position.x)
            {
                ultimaXPiso = pisos[i].transform.position.x;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D objColisionado)
    {
        if (objColisionado.CompareTag("fondo"))
        {
            Vector3 temp = objColisionado.transform.position;
            // Obtenemos el ancho real exacto usando el SpriteRenderer
            float anchoReal = objColisionado.GetComponent<SpriteRenderer>().bounds.size.x;

            temp.x = ultimaXFondo + anchoReal;
            objColisionado.transform.position = temp;
            ultimaXFondo = temp.x;
        }

        if (objColisionado.CompareTag("piso"))
        {
            Vector3 temp = objColisionado.transform.position;
            // Obtenemos el ancho real exacto usando el SpriteRenderer
            float anchoReal = objColisionado.GetComponent<SpriteRenderer>().bounds.size.x;

            temp.x = ultimaXPiso + anchoReal;
            objColisionado.transform.position = temp;
            ultimaXPiso = temp.x;
        }
    }
}
