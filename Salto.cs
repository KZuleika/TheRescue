using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Salto : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D RGB;
    //Transform transform;
    Animator animator;
    SpriteRenderer Sp;


    int saltosDisponibles = 0;
    bool OnAir;

    void Start()
    {
        RGB = this.gameObject.GetComponent<Rigidbody2D>();
        Sp = this.gameObject.GetComponent<SpriteRenderer>();
        animator = this.gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        RGB.velocity = new Vector2(Input.GetAxis("Horizontal") * 6, RGB.velocity.y);
        if (OnAir) animator.SetBool("Saltando", true);
        else animator.SetBool("Saltando", false);

        if (Input.GetAxis("Horizontal") > 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(RGB.velocity.x));
            Sp.flipX = false;

        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(RGB.velocity.x));
            Sp.flipX = true;
        }
        else if (Input.GetAxis("Horizontal") == 0)
        {
            animator.SetFloat("Speed", 0.0f);
        }
        if (Input.GetButtonDown("Salto") && 2 > saltosDisponibles)
        {
            RGB.AddForce(new Vector2(0f, 200f));
            saltosDisponibles++;
            //Debug.Log("Saltos Disponibles" + saltosDisponibles);
           
            if(saltosDisponibles==1) OnAir = true;
            if (OnAir) animator.SetBool("Saltando", true);
            
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo") || collision.gameObject.CompareTag("Plataforma"))
        {
            saltosDisponibles = 0;
            //Debug.Log(saltosDisponibles);
            OnAir = false;
        }

    }

}