using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager 
{
    public void CambiarTexto(AutoScript auto) 
    {
        TextMeshProUGUI texto = auto.GetComponentInChildren<TextMeshProUGUI>();
        texto.text = auto.Velocidad.ToString()+"km/h";
       
    }
}
