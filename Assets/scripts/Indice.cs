using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indice : MonoBehaviour
{
    public void Mover(int i, AutoScript[] autos)
    {
        transform.position = new Vector2(autos[i].transform.position.x - 1, autos[i].transform.position.y + 0.1f);
    }
}
