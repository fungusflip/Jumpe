using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject Character;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var script = Character.GetComponent <CharacterMove>();
        if (collider.CompareTag("Player"))
        {
            script.goal = true;
        }
    }
}