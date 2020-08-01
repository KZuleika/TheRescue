using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nivel3Aventura : MonoBehaviour
{
    public GameObject HistoriaPag3;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void DesplegarHistoriaPg3()
    {
        StartCoroutine(CargarHistoria());
    }
    IEnumerator CargarHistoria()
    {
        HistoriaPag3.SetActive(true);
        yield return new WaitForSecondsRealtime(4.5f);
        CargarSiguienteNivel();
        
    }
    public void CargarSiguienteNivel()
    {
        Time.timeScale = 1f;
        MainMenu.NivelesPorCompletar--;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
