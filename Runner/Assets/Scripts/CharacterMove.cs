using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private Rigidbody2D rg; // Note the corrected spelling of "Rigidbody"

    [SerializeField] float moveForce = 10.0f; // Adjust this value to control the force magnitude

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rg.AddForce(Vector3.right * moveForce);
    }
}