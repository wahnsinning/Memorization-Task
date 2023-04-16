using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

public class TMP : MonoBehaviour

{

    //für jedes wort ein leeres objekt, das den sound abspielen kann
    public GameObject wort1;
    public GameObject wort2;
    public GameObject wort3;
    public GameObject wort4;
    public GameObject wort5;
    public GameObject wort6;
    public GameObject wort8;
    public GameObject wort9;
    public GameObject wort10;
    public GameObject wort11;
    public GameObject wort12;
    public GameObject wort13;
    public GameObject wort14;
    public GameObject wort15;
    public GameObject wort18;
    public GameObject wort19;
    public GameObject wort21;
    

    public TextMeshProUGUI advice;

    public int activationIndex=0;

    // eine Variable für die Startzeit des Durchlaufs
    private float startTime;

    //bridge to the Timer script
    public Timer bridge;

    //bridge to the WriteCSV script 
    public WriteCSV csvbridge;

    //the main TMP Text
    public TextMeshProUGUI word;

    private bool ende = false;

    //alle Wortpaare sind hier                                     <----HIER KÖNNEN WORTPAARE VERÄNDERT WERDEN
    private string[] Wortpaare = new string[] {"Fyrverkerier - Feuerwerk",
        "Trollslända - Libelle",
        "Solros - Sonnenblume",
        "Snöflinga - Schneeflocke",
        "Lekplats - Spielplatz",
        "Smörgåsbord - Buffet",
        //"Lövträd - Laubbaum",
        "Fjäril - Schmetterling",
        "Fiskstim - Fischschule",
        "Bensinmack - Tankstelle",
        "Tågspår - Bahngleis",
        "Tivoli - Freizeitpark",
        "Skridskor - Schlittschuhe",
        "Havsbotten - Meeresgrund",
        "Småkaka - Plätzchen",
        //"Vattenpöl - Pfütze",
        //"Havsdjur - Meereskreatur",
        "Ljuslykta - Laterne",
        "Matbord - Esstisch",
        //"Flodhäst - Nilpferd",
        "Kryddhylla - Gewürzregal"};

    
    //list for reaction times
    List<string> ReactionTimes = new List<string>();
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyUp(KeyCode.Space)&& ende==false))
        {
            ButtonClicked();

            if (activationIndex == 0){
                StartCoroutine(ActivateOnce(wort1));
                advice.enabled = false;
            }

            else if (activationIndex == 1)
            {
                StartCoroutine(ActivateOnce(wort2));
                wort1.SetActive(false);
                startTime = Time.time;
            }
            else if (activationIndex == 2)
            {
                StartCoroutine(ActivateOnce(wort3));
                wort2.SetActive(false);
            }
            else if (activationIndex == 3)
            {
                StartCoroutine(ActivateOnce(wort4));
                wort3.SetActive(false);
            }
            else if (activationIndex == 4)
            {
                StartCoroutine(ActivateOnce(wort5));
                wort4.SetActive(false);
            }
            else if (activationIndex == 5)
            {
                StartCoroutine(ActivateOnce(wort6));
                wort5.SetActive(false);
            }
            else if (activationIndex == 6)
            {
                StartCoroutine(ActivateOnce(wort8));
                wort6.SetActive(false);
            }
            else if (activationIndex == 7)
            {
                StartCoroutine(ActivateOnce(wort9));
                wort8.SetActive(false);
            }
            else if (activationIndex == 8)
            {
                StartCoroutine(ActivateOnce(wort10));
                wort9.SetActive(false);
            }
            else if (activationIndex == 9)
            {
                StartCoroutine(ActivateOnce(wort11));
                wort10.SetActive(false);
            }
            else if (activationIndex == 10)
            {
                StartCoroutine(ActivateOnce(wort12));
                wort11.SetActive(false);
            }
            else if (activationIndex == 11)
            {
                StartCoroutine(ActivateOnce(wort13));
                wort12.SetActive(false);
            }
            else if (activationIndex == 12)
            {
                StartCoroutine(ActivateOnce(wort14));
                wort13.SetActive(false);
            }
            else if (activationIndex == 13)
            {
                StartCoroutine(ActivateOnce(wort15));
                wort14.SetActive(false);
            }
            else if (activationIndex == 14)
            {
                StartCoroutine(ActivateOnce(wort18));
                wort15.SetActive(false);
            }
            else if (activationIndex == 15)
            {
                StartCoroutine(ActivateOnce(wort19));
                wort18.SetActive(false);
            }
            else if (activationIndex == 16)
            {
                StartCoroutine(ActivateOnce(wort21));
                wort19.SetActive(false);
            }
            else if (activationIndex ==17)//LOOP CONDITION
            {
                StartCoroutine(ActivateOnce(wort1));
                wort21.SetActive(false);

                activationIndex=0;
            }

            //take the desired pair and display it
            word.text= Wortpaare[activationIndex];

            //erhöhe index damit es zum nächsten wortpaar springt 
            activationIndex += 1 ;
        }

        //END OF TRIAL CONDITION  
        if(bridge.time <= 0 && bridge.stoppuhr_gesamt.enabled==true){
                
            Time.timeScale = 0;
            Debug.Log("ENDE");
                
            // Entferne die erste Reaktionszeit aus der Liste
            ReactionTimes.RemoveAt(0);

            csvbridge.MakeCSV(ReactionTimes,Wortpaare,"Zeit,Wortpaar");

            //damit die end condition nicht mehrmals ausgeführt wird
            bridge.stoppuhr_gesamt.enabled=false;

            word.text="Fertig. CSV erstellt.";

            ende=true;
            
            }
        }

    void ButtonClicked()
    {
        //Add the reaction time to the list 
        ReactionTimes.Add(bridge.timeElapsed.ToString("F3", CultureInfo.InvariantCulture) ); 
        bridge.ResetTimer();
    }

    //this function makes sure that each empty object is activated for 3 seconds so that it can
    //play the sound before it is being deactivated
    IEnumerator ActivateOnce(GameObject ObjectToActivateOnce)
    {
        ObjectToActivateOnce.SetActive(true);
            
        yield return new WaitForSeconds(3.0f); // Wait for 2 seconds

        //deactivate so that there are less active objects while looking at a pair of words
        ObjectToActivateOnce.SetActive(false);
    }

    
}
