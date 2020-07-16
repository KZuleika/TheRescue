using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Historia : MonoBehaviour
{
    public GameObject[] HistoriaUI;
    public static int inicio = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (inicio < 1)
        {
            StartCoroutine(HistoriaPanelUNO());
            //StartCoroutine(HistoriaPaneDOS());
            inicio++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator HistoriaPanelUNO()
    {
        HistoriaUI[0].SetActive(true);
        yield return new WaitForSecondsRealtime(4.5f);
        HistoriaUI[0].SetActive(false);
        StartCoroutine(HistoriaPaneDOS());
    }
    IEnumerator HistoriaPaneDOS()
    {
        HistoriaUI[1].SetActive(true);
        yield return new WaitForSecondsRealtime(4.5f);
        HistoriaUI[1].SetActive(false);
    }
}
