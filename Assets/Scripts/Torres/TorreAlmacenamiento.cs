using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreAlmacenamiento : TorreBase
{
    [Header("Almacenamiento")]
    [SerializeField] private int incrementoLimiteTorres = 2;
    //private ControladorJugador controladorJugador;

   //private void Start()
   //{
   //    controladorJugador = GameObject.FindWithTag("Player").GetComponent<ControladorJugador>();
   //    if (controladorJugador != null)
   //    {
   //        controladorJugador.AumentarLimiteTorres(incrementoLimiteTorres);
   //        Debug.Log("Limite de torres aumentado.");
   //    }
   //}
   //
   //protected override void DestruirTorre()
   //{
   //    if (controladorJugador != null)
   //    {
   //        controladorJugador.AumentarLimiteTorres(-incrementoLimiteTorres);
   //    }
   //    base.DestruirTorre();
   //}
}
