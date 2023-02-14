using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esercizio_3 : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;

    private float volume = 1.0f;

    private float posPrecedente;
    private float posAttuale;

    void Start()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/TonoVolume");
        instance.start();
        posPrecedente = gameObject.transform.position.x;
    }

    void Update()
    {
        posAttuale = gameObject.transform.position.x;
        volume = 1.0f / (Punteggio.punteggio + 1);

        if (posAttuale == posPrecedente) {
            Debug.Log("Same");
            Debug.Log(posAttuale);
            Debug.Log(posPrecedente);
            volume = 1.0f / (Punteggio.punteggio + 1);
        } else {
            Debug.Log("Different");
            volume = 0.0f;
        }

        instance.setParameterByName("Volume_Dinamico", volume);

        posPrecedente = posAttuale;

        if (Variabili_Globali.azzeraAudio) {
            instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
}
