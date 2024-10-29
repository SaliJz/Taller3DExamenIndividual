using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorOleadas : MonoBehaviour
{
    [SerializeField] private GameObject enemigoPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private int enemigosMaximos = 10;
    //[SerializeField] private ControladorJugador jugador;

    private int oleadaActual = 1;
    private int enemigosEnJuego = 0;
    private int enemigosDerrotados = 0;

    void Start()
    {
        //StartCoroutine(IniciarOleadas());
    }

    //private IEnumerator IniciarOleadas()
    //{
    //    while (oleadaActual <= 5 && enemigosDerrotados < enemigosMaximos)
    //    {
    //        int cantidadEnemigos = Mathf.Pow(2, oleadaActual - 1);
    //        for (int i = 0; i < cantidadEnemigos; i++)
    //        {
    //            SpawnEnemigo();
    //            yield return new WaitForSeconds(1f);
    //        }
    //        oleadaActual++;
    //        yield return new WaitForSeconds(60); // Esperar 1 minuto entre oleadas
    //    }
    //}

    private void SpawnEnemigo()
    {
        Instantiate(enemigoPrefab, spawnPoint.position, Quaternion.identity);
        enemigosEnJuego++;
    }

    public void EnemigoDerrotado()
    {
        enemigosDerrotados++;
        if (enemigosDerrotados >= enemigosMaximos)
        {
            Debug.Log("¡Has ganado!");
            // Lógica para victoria
        }
    }

    public void EnemigoLlegadoAlFinal()
    {
        enemigosEnJuego--;
        if (enemigosEnJuego <= 0 && oleadaActual > 5)
        {
            Debug.Log("¡Victoria, todas las oleadas completadas!");
        }
    }
}