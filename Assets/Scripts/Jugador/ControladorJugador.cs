using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJugador : MonoBehaviour
{
    [Header("Monedas y Torretas")]
    [SerializeField] private int monedas = 0; // Monedas actuales del jugador
    [SerializeField] private int costoTorreta = 25; // Costo de una torreta
    [SerializeField] private GameObject prefabTorreta; // Prefab de la torreta
    [SerializeField] private Transform puntoGeneracion; // Punto donde se generará la torreta

    public void AñadirMonedas(int cantidad)
    {
        monedas += cantidad;
        Debug.Log("Monedas actuales: " + monedas);
    }

    public void SpawnTorreta()
    {
        if (monedas >= costoTorreta)
        {
            monedas -= costoTorreta;
            Instantiate(prefabTorreta, puntoGeneracion.position, Quaternion.identity);
            Debug.Log("Torreta generada. Monedas restantes: " + monedas);
        }
        else
        {
            Debug.Log("No tienes suficientes monedas para una torreta.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SpawnTorreta();
        }
    }

    public int ObtenerMonedas()
    {
        return monedas;
    }
}