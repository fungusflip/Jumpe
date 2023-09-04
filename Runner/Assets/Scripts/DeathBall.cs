using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBall : MonoBehaviour
{
    private Rigidbody2D rg;
    private string activeSceneName;
    public GameObject ui;

    [SerializeField] private int seconds;

    [SerializeField] private int rotation;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        StartCoroutine(Roler());
        var activeScene = SceneManager.GetActiveScene();
        activeSceneName = activeScene.name; 
        
    }
    
    private IEnumerator Roler()
    {
        yield return new WaitForSeconds(seconds);
        
        rg.angularVelocity = rotation;
        
        yield return new WaitForSeconds(1);

        rg.angularVelocity = rotation;
        
        yield return new WaitForSeconds(1);
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
