using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    private string activeSceneName; 

    void Start()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        activeSceneName = activeScene.name; 
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            SceneManager.LoadScene(activeSceneName);
        }
    }
}