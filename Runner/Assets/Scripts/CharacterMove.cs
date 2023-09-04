using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private Rigidbody2D rg;

    [SerializeField] private Transform startPosTransform;
    [SerializeField] private Transform cameraPos;
    [SerializeField] private Vector3 offset = new Vector3(0f, 0f, 0f);
    [SerializeField] public float moveSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] public float smoothTime;
    private bool firstStopped = false;
    private bool isJumping = true;
    public bool goal = false;
    private GameObject cameraObject;
    private Vector3 currentVelocity = Vector3.zero;


    void Start()
    {
        cameraObject = GameObject.FindWithTag("MainCamera");
        rg = GetComponent<Rigidbody2D>();
        rg.velocity = startPosTransform.position - transform.position;
    }

    // Coroutine for FIRST YIPPIE
    private IEnumerator WaitForDelay()
    {
        rg.velocity = transform.up * 5;
        
        yield return new WaitForSeconds(2);

        firstStopped = true;
        
        yield return new WaitForSeconds(1);
    }
    
    void Update()
    {
        Vector3 newPosition = transform.position + (offset);
        cameraPos.position = newPosition;
        // Movement Block for the FIRST YIPPIE
        if (rg.velocity.magnitude == 0)
        {
            StartCoroutine(WaitForDelay());
        }

        // Movement Block and CameraBlock for THE FIRST VROOM!!!!!
        if (firstStopped)
        {
            rg.velocity = new Vector2(moveSpeed, rg.velocity.y);
            
            //we can rotate untill the raycast maybe can feel ground?
            if (Input.GetKeyDown(KeyCode.Space)&& !isJumping)
            {
                
                rg.velocity = new Vector2(rg.velocity.x, jumpHeight);
                rg.angularVelocity = -136;
                isJumping = true;
                
            }
            

        }
        
    }

    void FixedUpdate()
        {
            if (firstStopped){
                if (!goal)
                {
                    cameraObject.transform.position = Vector3.SmoothDamp(
                        cameraObject.transform.position,
                        new Vector3(cameraPos.position.x, cameraPos.position.y, cameraObject.transform.position.z),
                        ref currentVelocity,
                        smoothTime
                    );
                }
            }
        }
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check for collision with ground or obstacle
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
