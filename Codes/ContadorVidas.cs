using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorVidas : MonoBehaviour
{
    public static int NumVidas;
    public Animator VidasAnim;
    Animator PlayerAnimator;
    public static bool EnemigoVivo = true;

    Rigidbody2D RGB;
    
    void Start()
    {
        RGB = this.gameObject.GetComponent<Rigidbody2D>();
        PlayerAnimator = this.gameObject.GetComponent<Animator>();
        NumVidas = 3;
    }

    void Update()
    {
        VidasAnim.SetInteger("Vidas", NumVidas);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemigo"))
        {
            if (EnemigoVivo)
            {
                CambioDeVidas();
                Debug.Log("Vidas=" + NumVidas.ToString());
            }

            RGB.AddForce(new Vector2(0, 250f));
            EnemigoVivo = true;
        }

        if (other.gameObject.CompareTag("Vacio"))
        {
            NumVidas = 0;
        }
    }

    void CambioDeVidas()
    {
        NumVidas--;
        VidasAnim.SetInteger("Vidas", NumVidas);
        if (NumVidas > 0) 
        {
            PlayerAnimator.SetTrigger("Hurt"); 
        }
    }
}
