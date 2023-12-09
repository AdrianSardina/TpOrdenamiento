using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Orden orden;
    AutoScript primeroEnLlegar;
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
        //for (int o = 0; o <= 1; o++)
        //{
        //    autos[o].Mover();
        //}
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
    public void Ordenar() 
    {
        StopAllCoroutines();
        StartCoroutine(OrdenarSeleccion());
    }
    public IEnumerator OrdenarSeleccion()
    {
        for (int i = 0; i < autos.Length; i++)
        {
            int minIndex = i;
            AutoScript minimo = autos[i];
           
           
            for (int j = i + 1; j < autos.Length; j++)
            {
               MoverAutos(autos[j],minimo);// el Minimo y el auto auto en el indice j se comparan
                
                Debug.Log("Estoy esperando");
                yield return new WaitUntil(() => primeroEnLlegar !=null);//Espero hasta que uno llegue a la meta
                Debug.Log("Llego un auto a la meta");



                Retornar(autos[j], minimo);// Los autos vueven a su posicion inicial
               // yield return new WaitForSeconds(1);
                if (primeroEnLlegar == minimo ) //Si el primero en llegar es el minimo entonces el otro se convierte en el minimo
                {
                    minIndex = j;
                    minimo = autos[j];
                }


                
                primeroEnLlegar = null;
                //if (autos[j].Velocidad < minimo.Velocidad) // compara con uno
                //{
                //    minIndex = j;
                //    minimo = autos[j];

                //}
            }
            Cambiar(autos, i, minIndex);
        }
        foreach (var item in autos)
        {
            Debug.LogError(item.Velocidad);
        }
    }
    private void Cambiar(AutoScript[] lista, int indice, int minimo)
    {
        Debug.LogWarning(lista[indice].transform.position);

        AutoScript temp = lista[indice];
        Vector2 pos = lista[indice].transform.position;
        lista[indice] = lista[minimo];
        lista[indice].transform.position = new Vector2(-9, lista[minimo].transform.position.y);
        lista[minimo] = temp;
        lista[minimo].transform.position = new Vector2(-9,pos.y);


    }
    void MoverAutos(AutoScript a1,AutoScript a2) 
    {
        a1.Mover();
        a2.Mover();
    }
    void Retornar(AutoScript a1, AutoScript a2)
    {
        a1.Parar();
        a2.Parar();
        a1.transform.position = new Vector2(-9,a1.transform.position.y);
        a2.transform.position = new Vector2(-9, a2.transform.position.y);

        // a2.transform.position = new Vector2(-9,transform.position.y);

    }   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        primeroEnLlegar = collision.gameObject.GetComponent<AutoScript>();
    }
}
