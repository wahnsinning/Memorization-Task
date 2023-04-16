
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    public TextMeshProUGUI stoppuhr;
    public TextMeshProUGUI stoppuhr_gesamt;


    public float timeElapsed;//für Rundenzeiten
    
    public float time;//für Gesamte Zeit

    //ich brauche diese verbindung da ich auf den zweiten space klick zeitpunkt zugreifen können muss, 
    //um den gesamttimer zu steuern
    public TMP TMP;

    //damit die gesamtzeit nicht während dem ersten wortpaar durchgehend auf 0 gesetzt wird
    private bool timestart=false;
    
    void Start()
    {
        
        timeElapsed = 0f;

        // gesamtzeit läuft noch nicht während der durchlesen-phase und muss daher deaktiviert werden
        stoppuhr_gesamt.enabled=false;
    }

    void Update()
    {
        if (TMP.activationIndex==1 && timestart==false){
            time=20f; //<----------------------------------GESAMTLAUFZEIT HIER ÄNDERN
            timestart=true;
            stoppuhr_gesamt.enabled=true;
        }

        timeElapsed += Time.deltaTime;
        time -= Time.deltaTime;
        stoppuhr.text = timeElapsed.ToString("F3");
        stoppuhr_gesamt.text = time.ToString("F0");
    }

    public void ResetTimer()
    {
        timeElapsed=0f;
    }
}