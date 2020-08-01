using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuentaMonedas : MonoBehaviour
{
    public static int CantMonedas;
    Rigidbody2D RGB;
    public Text CountText;

    void Start()
    {
        RGB = this.gameObject.GetComponent<Rigidbody2D>();
        CantMonedas = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            CantMonedas++;
            CountText.text = CantMonedas.ToString();
            Destroy(other.gameObject);
        }
    }

}
