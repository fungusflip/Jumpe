using UnityEngine;
using UnityEngine.SceneManagement;

public class Hurt : MonoBehaviour
{
private string activeSceneName;
public GameObject ui;

private void Start()
{

    var activeScene = SceneManager.GetActiveScene();
    activeSceneName = activeScene.name; 
}

private void OnTriggerEnter2D(Collider2D collider)
{
    var colliderTransform = collider.transform.parent;
    var parentGameObject = colliderTransform.gameObject;
    var script = ui.GetComponent<DeathCount>();
    int deathCount = PlayerPrefs.GetInt("deathCount");
    
    if (collider.CompareTag("Player"))
    {
        Destroy(parentGameObject);
        SceneManager.LoadScene(activeSceneName);
        deathCount++;
        script.SetDeathCount(deathCount);
    }
    
}

}