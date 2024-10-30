using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [Header("Atributos del Enemigo")]
    [SerializeField] private int daño = 10;
    [SerializeField] private float rangoAtaque = 5f;
    [SerializeField] private float tiempoEntreAtaques = 1.5f;

    private float tiempoUltimoAtaque;
    private Transform objetivoActual;

    private void Update()
    {
        if (objetivoActual == null || Vector3.Distance(transform.position, objetivoActual.position) > rangoAtaque)
        {
            BuscarObjetivo();
        }

        if (objetivoActual != null)
        {
            AtacarObjetivo();
        }
    }

    private void BuscarObjetivo()
    {
        Collider[] objetosEnRango = Physics.OverlapSphere(transform.position, rangoAtaque);
        Transform mejorObjetivo = null;
        int mejorPrioridad = int.MaxValue;

        foreach (Collider obj in objetosEnRango)
        {
            int prioridad = ObtenerPrioridad(obj.gameObject);
            if (prioridad < mejorPrioridad)
            {
                mejorPrioridad = prioridad;
                mejorObjetivo = obj.transform;
            }
        }

        objetivoActual = mejorObjetivo;
    }

    private int ObtenerPrioridad(GameObject obj)
    {
        if (obj.CompareTag("TorreDefensa"))
            return 1; // Mayor prioridad: Torre de Defensa
        else if (obj.CompareTag("TorreAtaque"))
            return 2; // Segunda prioridad: Torre de Ataque
        else if (obj.CompareTag("TorreAlmacenamiento"))
            return 3; // Tercera prioridad: Torre de Almacenamiento
        else if (obj.CompareTag("Player"))
            return 4; // Última prioridad: Jugador
        else
            return int.MaxValue; // Si no es un objetivo relevante, asignamos la prioridad más baja
    }

    private void AtacarObjetivo()
    {
        if (Time.time >= tiempoUltimoAtaque + tiempoEntreAtaques)
        {
            VidaBase vidaObjetivo = objetivoActual.GetComponent<VidaBase>();
            if (vidaObjetivo != null)
            {
                vidaObjetivo.RecibirDaño(daño);
                tiempoUltimoAtaque = Time.time;
            }
        }
    }
}

