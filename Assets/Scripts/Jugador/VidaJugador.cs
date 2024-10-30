using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaJugador : VidaBase
{
    [SerializeField] private string escenaMuerte;

    protected override void Muerte()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(escenaMuerte);
        Destroy(gameObject);
    }
}
