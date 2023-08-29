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
    private bool firstStopped = false;
    private bool firstJump = false;

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
            firstStopped = true;
            firstJump = true;
        }
        else
        {
            firstJump = false;

        }

        if (firstJump == true)
        {

        }

        if (firstStopped == true)
        {
        
        }
    }
}