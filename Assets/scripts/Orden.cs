using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orden : MonoBehaviour
{
    // Start is called before the first frame update
    private int o;
    public AutoScript au;
    void Start()
    {
        o = 0;
    }

    public void ObtenerAuto(AutoScript auto ) {

        au = auto;
    }
}
