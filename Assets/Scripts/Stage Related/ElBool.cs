using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ElBool : ScriptableObject
{
    public bool valor;

    public void Verdadero()
    {
        valor = true;
    }

    public void Falso()
    {
        valor = false;
    }
}
