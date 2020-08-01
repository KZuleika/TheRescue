using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MovBoton : MonoBehaviour
{
    Rigidbody2D RGB;
    Animator animator;
    SpriteRenderer Sp;

    int saltosDisponibles = 0;
    bool OnAir;

    void Start()
    {
        Time.timeScale = 1f;
        RGB = this.gameObject.GetComponent<Rigidbody2D>();
        Sp = this.gameObject.GetComponent<SpriteRenderer>();
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RGB.velocity = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * 6, RGB.velocity.y);
        if (OnAir) animator.SetBool("Saltando", true);
        else animator.SetBool("Saltando", false);


        if (CrossPlatformInputManager.GetAxis("Horizontal") > 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(RGB.velocity.x));
            Sp.flipX = false;

        }
        else if (CrossPlatformInputManager.GetAxis("Horizontal") < 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(RGB.velocity.x));
            Sp.flipX = true;
        }
        else if (CrossPlatformInputManager.GetAxis("Horizontal") == 0)
        {
            animator.SetFloat("Speed", 0.0f);
        }
        if (CrossPlatformInputManager.GetButtonDown("Jump") && 2 > saltosDisponibles)
        {
            RGB.AddForce(new Vector2(0f, 200f));
            saltosDisponibles++;

            if (saltosDisponibles == 1) OnAir = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Suelo") || collision.gameObject.CompareTag("Plataforma"))
        {
            saltosDisponibles = 0;
            OnAir = false;
        }

    }
}
