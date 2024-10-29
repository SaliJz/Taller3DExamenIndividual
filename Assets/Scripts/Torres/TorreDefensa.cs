using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreDefensa : TorreBase
{
    [Header("Atributos de Defensa")]
    [SerializeField] private int vidaExtra = 100;

    //protected override void Start()
    //{
    //    vida += vidaExtra; // Aumenta la vida inicial
    //    base.Start();
    //}

    protected override void DestruirTorre()
    {
        Debug.Log("Torre de Defensa destruida.");
        base.DestruirTorre();
    }
}
