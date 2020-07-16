using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuPrincipalUI;
    public GameObject MenuNivelesUI;
    public GameObject AdvertenciaUI;
    public GameObject[] PaginasUI;
    public static int NivelesPorCompletar = 3;
    int PagIndex;
    private void Start()
    {
        Time.timeScale = 1f;
        PagIndex = 0;
    }

    public void PlayGame()
    {
        MenuNivelesUI.SetActive(true);
        MenuPrincipalUI.SetActive(false);
    }

    public void BotonNivel_1()
    {
        if(NivelesPorCompletar<=3)
            SceneManager.LoadScene("NivelUNO");
    }

    public void BotonNivel_2()
    {
        if (NivelesPorCompletar<=2)
            SceneManager.LoadScene("NivelDOS");
        else
        {
            AdvertenciaUI.SetActive(true);
            MenuNivelesUI.SetActive(false);
        }

    }

    public void BotonNivel_3()
    {
        if (NivelesPorCompletar <= 1)
            SceneManager.LoadScene("NivelTRES");
        else
        {
            AdvertenciaUI.SetActive(true);
            MenuNivelesUI.SetActive(false);
        }
            
    }

    public void Breakout()
    {
        if (NivelesPorCompletar <= 0)
            SceneManager.LoadScene("Breakout");
        else
        {
            AdvertenciaUI.SetActive(true);
            MenuNivelesUI.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void Instrucciones()
    {
        PaginasUI[PagIndex].SetActive(true);
        MenuPrincipalUI.SetActive(false);
    }
    public void Regresar()
    {
        if (AdvertenciaUI.activeInHierarchy)
        {
            AdvertenciaUI.SetActive(false);
            MenuNivelesUI.SetActive(true);
        }
        else
        {
            PaginasUI[PagIndex].SetActive(false);
            PaginasUI[--PagIndex].SetActive(true);
        }
        
    }
    public void Siguiente()
    {
        Debug.Log(PagIndex);
        PaginasUI[PagIndex].SetActive(false);
        PaginasUI[++PagIndex].SetActive(true);
    }
    public void MenuPrincipal()
    {
        AdvertenciaUI.SetActive(false);
        PaginasUI[PagIndex].SetActive(false);
        MenuNivelesUI.SetActive(false);
        MenuPrincipalUI.SetActive(true);
        PagIndex = 0;
    }
}
