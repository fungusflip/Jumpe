using UnityEngine;
using UnityEngine.SceneManagement;

public class Hurt : MonoBehaviour
{
private string activeSceneName; 

void Start()
{
    Scene activeScene = SceneManager.GetActiveScene();
    activeSceneName = activeScene.name; 
}

private void OnTriggerEnter2D(Collider2D collider)
{
    Transform colliderTransform = collider.transform.parent;
    GameObject parentGameObject = colliderTransform.gameObject;

    if (collider.CompareTag("Player"))
    {
        Destroy(parentGameObject);
        SceneManager.LoadScene(activeSceneName);
    }
}
}