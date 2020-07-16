using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BreakoutMenus : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject PerdisteUI;
    public GameObject PanelSalirUI;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("Jugando");
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
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
        BallScript.LadrillosDestruidos = 0;
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
}
