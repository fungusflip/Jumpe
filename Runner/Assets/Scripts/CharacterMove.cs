using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private Rigidbody2D rg;

    [SerializeField] private Transform targetTransform;
    [SerializeField] private Transform CameraPos;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float smoothTime = 0.3f;
    private bool firstStopped = false;
    private GameObject cameraObject;
    private Vector3 currentVelocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        // For my headache and this is probably going to be a mobile game if it was something to be used + we don't need more frames!
        Application.targetFrameRate = 60;

        cameraObject = GameObject.FindWithTag("MainCamera");
        rg = GetComponent<Rigidbody2D>();
        
        // For StartPos
        rg.velocity = targetTransform.position - transform.position;
    }

    // Coroutine for delayed start
    private IEnumerator WaitForDelay()
    {
        rg.velocity = transform.up * 3;
        
        yield return new WaitForSeconds(2);

        firstStopped = true;
        Debug.Log(firstStopped);
        
        yield return new WaitForSeconds(1);
    }

    // FixedUpdate is called once per fixed frame update
    void FixedUpdate()
    {
        // Movement Block
        if (rg.velocity.magnitude == 0)
        {
            StartCoroutine(WaitForDelay());
        }

        // Movement Block and CameraBlock
        if (firstStopped)
        {
            rg.velocity = new Vector2(moveSpeed, rg.velocity.y);
            cameraObject.transform.position = Vector3.SmoothDamp(
                cameraObject.transform.position,
                new Vector3(CameraPos.position.x, CameraPos.position.y, cameraObject.transform.position.z),
                ref currentVelocity,
                smoothTime
            );
            


            if (Input.GetKeyDown(KeyCode.Space))
            {
                rg.velocity = new Vector2(rg.velocity.x, jumpHeight);
            }
        }
    }
}
