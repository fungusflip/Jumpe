using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Faster : MonoBehaviour
{
    [SerializeField] private GameObject CharacterMove;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        var script = CharacterMove.GetComponent<CharacterMove>();
        if (collider.CompareTag("Player"))
        {
            Destroy(this.GameObject());
            script.moveSpeed +=3;
            script.smoothTime -= 0.075f;

        }
    }
}