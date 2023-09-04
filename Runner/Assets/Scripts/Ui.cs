using UnityEngine;
using UnityEngine.SceneManagement;

public class Ui : MonoBehaviour
{
    private string activeSceneName; 
    void Start()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        activeSceneName = activeScene.name; 
    }
    
    public void OnClickGoAgane()
    {
        SceneManager.LoadScene(activeSceneName);
    }

}
