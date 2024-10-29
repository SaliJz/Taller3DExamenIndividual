using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreAtaque : TorreBase
{
    [Header("Atributos de Ataque")]
    [SerializeField] private GameObject proyectilPrefab;
    [SerializeField] private float frecuenciaDisparo = 1f; // Tiempo entre disparos
    private float tiempoDesdeUltimoDisparo = 0f;

    private void Update()
    {
        tiempoDesdeUltimoDisparo += Time.deltaTime;
        if (tiempoDesdeUltimoDisparo >= frecuenciaDisparo)
        {
            Atacar();
            tiempoDesdeUltimoDisparo = 0f;
        }
    }

    private void Atacar()
    {
        Collider[] enemigosEnRango = Physics.OverlapSphere(transform.position, rango, LayerMask.GetMask("Enemigo"));
        if (enemigosEnRango.Length > 0)
        {
            Transform enemigoObjetivo = enemigosEnRango[0].transform;
            GameObject proyectil = Instantiate(proyectilPrefab, transform.position, Quaternion.identity);
            proyectil.GetComponent<Proyectil>().ConfigurarObjetivo(enemigoObjetivo);
            Debug.Log("Disparando a enemigo.");
        }
    }
}
