using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    AutoScript[] autos;
    TextManager textManager;
    void Start()
    {
        autos = FindObjectsOfType<AutoScript>();
        textManager = new TextManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mezclar() 
    {
        foreach (AutoScript auto in autos) 
        {
            auto.CambiarVelocidad(UnityEngine.Random.Range(1,101));
            textManager.CambiarTexto(auto);
        }
    }
}
