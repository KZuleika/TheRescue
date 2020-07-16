using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject PerdisteUI;
    public GameObject FlechasUI;
    public GameObject PanelSalirUI;
    public Animator PlayerAnimator;


    // Update is called once per frame
    void Update()
    {
        if (ContadorVidas.NumVidas <= 0)
        {
            StartCoroutine(PantallaPerdiste());
        }
        if (PerdisteUI.activeInHierarchy)
        {
            Time.timeScale = 0f;
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        FlechasUI.SetActive(true);
        Time.timeScale = 1f;
        Debug.Log("Jugando");
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        FlechasUI.SetActive(false);
        Time.timeScale = 0f;
        Debug.Log("Pausado");
    }

    public void MenuPrincipal()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("PantallaInicio");
    }

    public void Reintentar()
    {
        ContadorVidas.NumVidas = 3;
        CuentaMonedas.CantMonedas = 0;
        Time.timeScale = 1f;
        PerdisteUI.SetActive(false); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void IntentaSalir()
    {
        PanelSalirUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void ButtonNo()
    {
        PanelSalirUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void SalirBoton()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
    
    IEnumerator PantallaPerdiste ()
    {
        PlayerAnimator.SetTrigger("Death");
        
        yield return new WaitForSecondsRealtime(1f);

        PerdisteUI.SetActive(true);
    }
}
