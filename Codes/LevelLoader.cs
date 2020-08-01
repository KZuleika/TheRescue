using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    //public Animator transition;
    public GameObject CirculoNegro;
    public float TransitionTime = 2f;

    private void Start()
    {
        if(Historia.inicio != 0)
        {
            StartCoroutine(InicioDeEscena()); 
        }
        
    }

    IEnumerator InicioDeEscena()
    {
        CirculoNegro.SetActive(true);
        yield return new WaitForSeconds(TransitionTime);
        CirculoNegro.SetActive(false);
    }
}
