using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Orden orden;
    bool termino;
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
        for (int o = 0; o <= 1; o++)
        {
            autos[o].Mover();
        }
    }

    public void Mezclar()
    {
        int i = 0;
        foreach (AutoScript auto in autos)
        {
            auto.CambiarVelocidad(UnityEngine.Random.Range(1, 20));
            textManager.CambiarTexto(auto);
            auto.transform.position = new Vector2(-9,2-i);
            i++;
        }
    }
    public void OrdenAuto(float i) {

        ordenAuto[o] = i;
        for (int o=0;o<=4;o++) {
            Debug.Log(ordenAuto[o]);
        }
        o++;

    }
    public IEnumerator OrdenarSeleccion()
    {
        for (int i = 0; i < autos.Length; i++)
        {
            int minIndex = i;
            AutoScript minimo = autos[i];
            termino = false;
            Debug.Log("Estoy esperando");
            yield return new WaitUntil(() => termino == true);
            Debug.Log("Llego un auto a la meta");
            for (int j = i + 1; j < autos.Length; j++)
            {
                if (autos[j].Velocidad < minimo.Velocidad) // compara con uno
                {
                    minIndex = j;
                    minimo = autos[j];

                }
            }
            Cambiar(autos, i, minIndex);
        }
        //foreach (AutoScript auto in autosDesordenados) {
        //    Debug.Log(auto.Velocidad);
        //}

    }
    private void Cambiar(AutoScript[] lista, int v1, int v2)
    {
        AutoScript temp = lista[v1];
        lista[v1] = lista[v2];
        lista[v2] = temp;


    }
}
