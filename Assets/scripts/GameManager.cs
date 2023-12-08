using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Orden orden;
    AutoScript[] autos;
    float[] ordenAuto;
    int o;
    TextManager textManager;
    void Start()
    {
        autos = FindObjectsOfType<AutoScript>();
        textManager = new TextManager();
        ordenAuto = new float[5];
        o = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mezclar()
    {
        foreach (AutoScript auto in autos)
        {
            auto.CambiarVelocidad(UnityEngine.Random.Range(1, 20));
            textManager.CambiarTexto(auto);
        }
    }
    public void OrdenAuto(float i) {

        ordenAuto[o] = i;
        for (int o=0;o<=4;o++) {
            Debug.Log(ordenAuto[o]);
        }
        o++;

    }
  
}
