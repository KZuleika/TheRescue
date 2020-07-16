using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteEnemigos : MonoBehaviour
{
    Rigidbody2D RGB;
    Animator EnemyAnimator;
   
    // Start is called before the first frame update
    void Start()
    {
        RGB = this.gameObject.GetComponent<Rigidbody2D>();
        EnemyAnimator = this.gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EnemyAnimator.SetTrigger("Aplastado");
            ContadorVidas.EnemigoVivo = false;
            Destroy(this.gameObject, 1f);
        }
    }

}
