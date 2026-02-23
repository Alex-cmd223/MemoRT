using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
    public void IrAHome()
    {
        SceneManager.LoadScene("Home"); 
    }
}