using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public static Player instancia;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private Animator anim;
    public bool yaVolo, estaVivo;
    public float valorOffset = 0;

    private float velocidad = 4.0f, fuerzarebote = 4.0f, velocidadAngulo = 50; // aqui podria cambiar los valores si quiero agregar difficultad maybe
    private Button btnvolar;

    private int score;
    public AudioSource reproductor;
    public AudioClip sndPunto, sndMuere, sndVuelo;
    public Text txtScore;

    void Awake()
    {
        score = 0;
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
                reproductor.clip = sndVuelo;
                reproductor.Play();
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

    private void AsignaPosXCamara()
    {
        CamaraScript.offsetX = Camera.main.transform.position.x - transform.position.x - valorOffset;
    }

    public float ObtenPosX()
    {
        return transform.position.x;
    }

    private void VuelaPajaro()
    {
        yaVolo = true;
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "tuboGrupo")
        {
            score++;
            txtScore.text = score.ToString();
            reproductor.clip = sndPunto;
            reproductor.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "piso" || obj.gameObject.tag == "tubo")
        {
            if (estaVivo)
            {
                estaVivo = false;
                anim.SetTrigger("muere");
                reproductor.clip = sndMuere;
                reproductor.Play();

                // activa menu inicio
                GameManager.instancia.ActivarGameOver();

            }
        }
    }
}
