using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimo : MonoBehaviour
{
    public  void Mover(AutoScript minimo)
    {
       transform.position = new Vector2(minimo.transform.position.x - 1, minimo.transform.position.y - 0.2f);

    }
}
