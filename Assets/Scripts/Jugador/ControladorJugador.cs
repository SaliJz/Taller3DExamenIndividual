using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using TMPro;

public class ControladorJugador : MonoBehaviour
{
    [Header("Monedas y Torretas")]
    [SerializeField] private int monedas = 0;
    [SerializeField] private int limiteTorres = 3;
    private int torresActuales = 0;

    [SerializeField] private GameObject prefabTorreAtaque;
    [SerializeField] private GameObject prefabTorreAlmacenamiento;
    [SerializeField] private GameObject prefabTorreDefensa;
    [SerializeField] private Transform puntoGeneracion;

    [SerializeField] TextMeshProUGUI texto; // Texto temporal en el HUD

    private string torreSeleccionada = ""; // Almacena el tipo de torre seleccionado

    private void Start()
    {
        texto.gameObject.SetActive(false);
    }

    void Update()
    {
        SeleccionarTorre(); // Detecta la selecci�n de la torre con las teclas 1, 2, 3

        if (Input.GetKeyDown(KeyCode.E) && torreSeleccionada != "")
        {
            SpawnTorreta(torreSeleccionada);
        }
    }

    private void SeleccionarTorre()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            torreSeleccionada = "Ataque";
            MostrarMensaje("Torre de Ataque seleccionada");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            torreSeleccionada = "Almacenamiento";
            MostrarMensaje("Torre de Almacenamiento seleccionada");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            torreSeleccionada = "Defensa";
            MostrarMensaje("Torre de Defensa seleccionada");
        }
    }

    public void A�adirMonedas(int cantidad)
    {
        monedas += cantidad;
        MostrarMensaje("Monedas a�adidas: " + cantidad);
    }

    public void SpawnTorreta(string tipoTorre)
    {
        int costoTorreta = 0;
        GameObject prefabTorreta = null;

        switch (tipoTorre)
        {
            case "Ataque":
                costoTorreta = prefabTorreAtaque.GetComponent<TorreAtaque>().ObtenerCosto();
                prefabTorreta = prefabTorreAtaque;
                break;
            case "Almacenamiento":
                costoTorreta = prefabTorreAlmacenamiento.GetComponent<TorreAlmacenamiento>().ObtenerCosto();
                prefabTorreta = prefabTorreAlmacenamiento;
                break;
            case "Defensa":
                costoTorreta = prefabTorreDefensa.GetComponent<TorreDefensa>().ObtenerCosto();
                prefabTorreta = prefabTorreDefensa;
                break;
            default:
                MostrarMensaje("Tipo de torre no v�lido.");
                return;
        }

        if (monedas >= costoTorreta && torresActuales < limiteTorres)
        {
            monedas -= costoTorreta;
            Instantiate(prefabTorreta, puntoGeneracion.position, Quaternion.identity);
            torresActuales++;
            MostrarMensaje($"{tipoTorre} generada. Monedas restantes: {monedas}");
        }
        else
        {
            MostrarMensaje("No tienes suficientes monedas o has alcanzado el l�mite de torres.");
        }
    }

    public void AumentarLimiteTorres(int incremento)
    {
        limiteTorres += incremento;
        MostrarMensaje("Se incremento el limite de torres: " + incremento);
    }

    public int ObtenerMonedas()
    {
        return monedas;
    }

    private IEnumerator TemporizadorMensaje(float duracion)
    {
        yield return new WaitForSeconds(duracion);
        texto.text = ""; // Limpia el texto despu�s de la duraci�n establecida
    }

    private void MostrarMensaje(string mensaje)
    {
        texto.gameObject.SetActive(true);
        texto.text = mensaje;
        StopAllCoroutines(); // Detiene cualquier corrutina anterior para reiniciar el temporizador
        StartCoroutine(TemporizadorMensaje(5f)); // Inicia el temporizador para limpiar el mensaje
    }
}