using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private Rigidbody2D rg; // Note the corrected spelling of "Rigidbody"

    [SerializeField] private Transform targetTransform;
    [SerializeField] float moveForce = 10.0f; // Adjust this value to control the force magnitude
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform cameraPos;
    private bool Stopped = false;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        rg.velocity = targetTransform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (rg.velocity.magnitude == 0)
        {
            Stopped = true;
        }
        Debug.Log(Stopped);

        if (Stopped == true)
        {
            rg.add
        }
    }
}