using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreBase : MonoBehaviour
{
    [Header("Atributos Comunes de la Torre")]
    [SerializeField] protected int vida = 50;
    [SerializeField] protected float rango = 5f;
    [SerializeField] protected int costo = 25;

    public virtual void Start()
    {

    }

    public virtual void RecibirDaño(int cantidad)
    {
        vida -= cantidad;
        if (vida <= 0)
        {
            DestruirTorre();
        }
    }

    protected virtual void DestruirTorre()
    {
        Destroy(gameObject);
    }

    public int ObtenerCosto()
    {
        return costo;
    }
}
