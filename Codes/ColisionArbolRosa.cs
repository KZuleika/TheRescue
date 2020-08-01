using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColisionArbolRosa : MonoBehaviour
{
    //public Animator transition;
    //public float TransitionTime = 1f;
    public GameObject NivelCompletadoUI;
    public GameObject NivelIncompletoUI;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //CuentaMonedas.CantMonedas = 5;
            Time.timeScale = 0f;
            if (CuentaMonedas.CantMonedas == 5)
            {
                NivelCompletadoUI.SetActive(true);
            }
            else if (CuentaMonedas.CantMonedas < 5)
            {
                NivelIncompletoUI.SetActive(true);
            }

        }
    }

    public void CargarSiguienteNivel()
    {
        Time.timeScale = 1f;
        ContadorVidas.NumVidas = 3;
        CuentaMonedas.CantMonedas = 0;

        MainMenu.NivelesPorCompletar--;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
