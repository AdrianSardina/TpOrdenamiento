using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScript : MonoBehaviour
{
    Orden orden;
    GameManager game;
    float velocidad;
    public float Velocidad { get => velocidad; }
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        game = FindObjectOfType<GameManager>();
    }

   
    
   public void Mover() 
    {
        rb.velocity = new Vector2(Velocidad,0);
    }
    public void Parar() 
    {
        rb.velocity = Vector2.zero;
    } 
    public void CambiarVelocidad(float v) 
    {
        velocidad = v;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.collider.CompareTag("meta")) {
        //    // orden.ObtenerAuto(this);
        //    game.OrdenAuto(velocidad);
        
        //}
    }
}
