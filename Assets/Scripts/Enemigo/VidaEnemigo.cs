using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : VidaBase
{
    [SerializeField] private int monedasPorDerrota = 10;
    private ControladorJugador controladorJugador;

    protected override void Start()
    {
        base.Start();
        controladorJugador = GameObject.FindWithTag("Player").GetComponent<ControladorJugador>();
    }

    protected override void Muerte()
    {
        if (controladorJugador != null)
        {
            controladorJugador.AñadirMonedas(monedasPorDerrota);
        }
        Destroy(gameObject);
    }
}