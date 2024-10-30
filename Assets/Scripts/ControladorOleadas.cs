using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorOleadas : MonoBehaviour
{
    [SerializeField] private GameObject enemigoPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private ControladorJugador jugador;

    [SerializeField] private string escenaVictoria;

    private int[] enemigosPorOleada = { 1, 2, 4, 8, 16 };

    private int oleadaActual = 0;

    private int enemigosDerrotados = 0;

    void Start()
    {
        StartCoroutine(IniciarOleadas());
    }

    private IEnumerator IniciarOleadas()
    {
        while (oleadaActual < enemigosPorOleada.Length)
        {
            for (int i = 0; i < enemigosPorOleada[oleadaActual]; i++)
            {
                SpawnEnemigo();
                yield return new WaitForSeconds(1f);
            }
            oleadaActual++;
            yield return new WaitForSeconds(60); // Esperar 1 minuto entre oleadas
        }
    }

    private void SpawnEnemigo()
    {
        Instantiate(enemigoPrefab, spawnPoint.position, Quaternion.identity);
    }

    public void EnemigoDerrotado()
    {
        enemigosDerrotados++;
        if (enemigosDerrotados >= enemigosPorOleada[oleadaActual])
        {
            oleadaActual++;
        }
    }
}