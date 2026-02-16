using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    public String sceneName;


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
        Debug.Log("Collision");
            SceneManager.LoadScene(sceneName);
        }
    }
}
