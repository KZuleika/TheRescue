using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    float BallForce = 420f;
    public GameObject PerdisteUI;
    public GameObject NivelCompletoUI;
    public GameObject GanasteUI;
    public static int LadrillosDestruidos = 0;

    Vector3 BallPosition;
    Vector3 BallLimits;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody ballrig = GetComponent<Rigidbody>();
        ballrig.AddForce(0, BallForce, 0);
        BallLimits = new Vector3(9.0f, 5.0f, 0.0f);
    }

    private void Update()
    {
        if(LadrillosDestruidos == 35)
        {
            Time.timeScale = 0f;
            NivelCompletoUI.SetActive(true);
        }

        BallPosition = transform.position;

        if(transform.position.x > BallLimits.x ||
            transform.position.y > BallLimits.y)
        {
            Perdiste();
        }
        if(transform.position.z != BallLimits.z)
        {
            transform.position = new Vector3(BallPosition.x, BallPosition.y, 0.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Vacio"))
        {
            Perdiste();
        }
    }

    public void Ganaste()
    {
        NivelCompletoUI.SetActive(false);
        GanasteUI.SetActive(true);
    }

    public void Perdiste()
    {
        Time.timeScale = 0f;
        PerdisteUI.SetActive(true);
    }
}
