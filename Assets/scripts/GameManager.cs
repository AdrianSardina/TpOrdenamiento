using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Orden orden;
    AutoScript primeroEnLlegar;
    bool llegaronAMeta;
    AutoScript[] autos;
    float[] ordenAuto;
    GameObject indice,minimo2;
    int o;
    TextManager textManager;
    void Start()
    {
        autos = FindObjectsOfType<AutoScript>();
        textManager = new TextManager();
        ordenAuto = new float[5];
        o = 0;
        llegaronAMeta = false;
        indice = GameObject.Find("indice");
        minimo2 = GameObject.Find("minimo");
    }
    public void Mezclar()
    {
        int i = 0;
        foreach (AutoScript auto in autos)
        {
            auto.CambiarVelocidad(UnityEngine.Random.Range(1, 20));
            textManager.CambiarTexto(auto);
            auto.transform.position = new Vector2(-7.5f,2-i*1.5f);
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
            indice.GetComponent<Indice>().Mover(i,autos);
            int minIndex = i;
            AutoScript minimo = autos[i];
          
            for (int j = i + 1; j < autos.Length; j++)
            {
                
                MoverAutos(autos[j],minimo);// el Minimo y el auto en el indice j se comparan

                minimo2.GetComponent<Minimo>().Mover(minimo);
                
                yield return new WaitUntil(() => o>1);//Espero hasta que uno llegue a la meta
 
                Retornar(autos[j], minimo);// Los autos vueven a su posicion inicial
                if (primeroEnLlegar == minimo ) //Si el primero en llegar es el minimo entonces el otro se convierte en el minimo
                {
                    minIndex = j;
                    minimo = autos[j];
                }


                o = 0;
                primeroEnLlegar = null;
                llegaronAMeta = false;
                
            }
            Cambiar(autos, i, minIndex);
        }
        
    }
    private void Cambiar(AutoScript[] lista, int indice, int minimo)
    {
        AutoScript temp = lista[indice];
        Vector2 pos = lista[indice].gameObject.transform.position;


        lista[indice].gameObject.transform.position = new Vector2(-7.5f, lista[minimo].gameObject.transform.position.y);
        lista[indice] = lista[minimo];


        lista[minimo].gameObject.transform.position = new Vector2(-7.5f, pos.y);
        lista[minimo] = temp;

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
        a1.transform.position = new Vector2(-7.5f, a1.transform.position.y);
        a2.transform.position = new Vector2(-7.5f, a2.transform.position.y);
    }   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (o == 0)
        {
            primeroEnLlegar = collision.gameObject.GetComponent<AutoScript>();
            primeroEnLlegar.Parar();
        }
        o++;
    }
}
