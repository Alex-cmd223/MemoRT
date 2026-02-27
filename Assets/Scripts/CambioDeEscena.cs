using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;
using System;

public class CambioDeEscena : MonoBehaviour
{   
    IEnumerator VerificarServidorYEjecutar(Action accionExitosa)
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost:8001/Home"))
        {
            www.timeout = 5; 
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("No se conectó al servidor: " + www.error);
                
            }
            else
            {
                Debug.Log("Servidor disponible, cambiando de escena...");
                accionExitosa.Invoke(); 
            }
        }
    }

    IEnumerator TalkToPython()
    {
        WWWForm form = new WWWForm();
        form.AddField("user", "pablo");
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8001/Home", form))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string txt = www.downloadHandler.text;
                Debug.Log(txt);
                SceneManager.LoadScene("Home"); 
            }
        }   
    }
    public void IrAHome()
    {
        StartCoroutine(TalkToPython());
    }
    public void IrAInicioSesion()
    {
        StartCoroutine(VerificarServidorYEjecutar(() => {
            SceneManager.LoadScene("Inicio sesion");
        }));
    }
    public void IrARegistro()
    {
        StartCoroutine(VerificarServidorYEjecutar(() => {
            SceneManager.LoadScene("Registro");
        }));
    }
    public void IrAMenu()
    {
        StartCoroutine(VerificarServidorYEjecutar(() => {
            SceneManager.LoadScene("Menu");
        }));
    }
}