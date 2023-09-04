using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject Character;
    [SerializeField] private GameObject WinUI;
    [SerializeField] private GameObject WinNumber;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var script = Character.GetComponent <CharacterMove>();
        if (collider.CompareTag("Player"))
        {
            script.goal = true;
            WinUI.SetActive(true);
            WinNumber.SetActive(false);
        }
    }
}