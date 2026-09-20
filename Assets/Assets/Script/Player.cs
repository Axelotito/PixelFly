using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    public static Player instancia;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private Animator anim;
    public bool yaVolo, estaVivo;
    public float valorOffset = 0;

    private float velocidad = 3.0f, fuerzarebote = 4.0f, velocidadAngulo = 15;
    private Button btnvolar;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        estaVivo = true;
        btnvolar = GameObject.FindGameObjectWithTag("btnVolar").GetComponent<Button>();
        btnvolar.onClick.AddListener( () => VuelaPajaro() );
        AsignaPosXCamara();
    }
       

    void FixedUpdate()
    {
        if (estaVivo) 
        {
            Vector3 temp = transform.position;
            temp.x += velocidad * Time.deltaTime;
            transform.position = temp;

            if (yaVolo)
            {
                yaVolo = false;
                rb2d.linearVelocity = new Vector2(0, fuerzarebote);
                anim.SetTrigger("volando");
            }

            if (rb2d.linearVelocity.y >= 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else 
            {
                float angulo = 0;
                angulo = Mathf.Lerp(0, -90 , -rb2d.linearVelocity.y / velocidadAngulo);
                transform.rotation = Quaternion.Euler(0,0,angulo);
            }

        }
    }

    private float AsignaPosXCamara()
    {
        return transform.position.x;
    }

    private void VuelaPajaro()
    {
        yaVolo = true;
    }
}
