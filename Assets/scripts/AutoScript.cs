using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScript : MonoBehaviour
{
    float velocidad;
    public float Velocidad { get => velocidad; }
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Mover() 
    {
        rb.velocity = new Vector2(velocidad,0);
    }

    public void CambiarVelocidad(float v) 
    {
        velocidad = v;
    }
}
