using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    private bool eventActive = false;
    [SerializeField] private float eventDuration = 60f;
    private float timer;
    [SerializeField] TextMeshProUGUI timerText;

    void Start()
    {
        StartCoroutine(IniciarOleadas());
    }

    private void Update()
    {
        if (eventActive)
        {
            timer -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            if (timer <= eventDuration / 2 && timer > 10)
            {
                timerText.color = Color.yellow;
            }

            else if (timer <= 10 && timer > 0)
            {
                timerText.color = Color.red;
            }

            else if (timer <= 0)
            {
                timerText.gameObject.SetActive(false);
            }
        }
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
            yield return new WaitForSeconds(eventDuration); // Esperar 1 minuto entre oleadas
        }
    }

    private void SpawnEnemigo()
    {
        eventActive = true;
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