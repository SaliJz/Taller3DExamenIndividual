using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBase : MonoBehaviour
{
    [SerializeField] protected int vidaMaxima = 100;
    [SerializeField] protected int vidaActual;

    protected virtual void Start()
    {
        vidaActual = vidaMaxima;
    }

    public virtual void RecibirDaño(int cantidad)
    {
        vidaActual -= cantidad;
        if (vidaActual <= 0)
        {
            Muerte();
        }
    }

    protected virtual void Muerte()
    {
        Destroy(gameObject);
    }

    public int VidaActual()
    {
        return vidaActual;
    }
    public int VidaMaxima()
    {
        return vidaMaxima;
    }
}
