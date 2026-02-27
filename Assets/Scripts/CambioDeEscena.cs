using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
    public void IrAHome()
    {
        SceneManager.LoadScene("Home"); 
    }
    public void IrAInicioSesion()
    {
        SceneManager.LoadScene("Inicio sesion");
    }
    public void IrARegistro()
    {
        SceneManager.LoadScene("Registro");
    }
    public void IrAMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}