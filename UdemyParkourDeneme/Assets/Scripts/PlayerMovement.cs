using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // movement
    private CharacterController controller;
    public float speed = 1f;

    // Camera Controller
    public float mouseSensitivity = 100f;
    private float xRotation = 0f;

    // jump and gravity
    private Vector3 velocity;
    private float gravity = -9.81f;
    public Transform groundChecker;
    public float groundCheckerRadius;
    public LayerMask obstacleLayer;
    private bool isGround;
    public float jumpHeight = 0.1f;
    public float gravityDivide = 100f;
    public float jumpSpeed = 10;

    private float aTimer;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Check character is ground
        // yere değdiğinde true vericek isground, bize yere değmediğinde yani false olan değer lazım.
        isGround = Physics.CheckSphere(groundChecker.position, groundCheckerRadius, obstacleLayer);

        // movement
        // transform.right = 1,0,0     transform.forward = 0,0,1
        Vector3 moveInputs = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        Vector3 moveVelocity = moveInputs * Time.deltaTime * speed;

        controller.Move(moveVelocity);

        // Camera Controller
        // mousu x ekseninde hareket ettirdiğimde y ekseninde dönmesi lazım. Çünkü y ekseninde sağa sola dönüyor.
        transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity, 0);
        xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);


        // jump & gravity
        // hangi layerlara değdiği zaman etkileşime geçecek bunun için kullandık obstaclelayerı
        // yani sadece obstacle a çarptığında true ya da false oynatsın 
        // yere değdiğinde true vericek isground, bize yere değmediğinde yani false olan değer lazım.
        if (!isGround) 
        {
            velocity.y += gravity * Time.deltaTime / gravityDivide;
            aTimer += Time.deltaTime / 3;
            speed = Mathf.Lerp(10, jumpSpeed, aTimer);
        }
        else
        {
            velocity.y = -0.05f;
            speed = 10;
            aTimer = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGround) 
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity / gravityDivide * Time.deltaTime); 
        }



        
        controller.Move(velocity);



    }
}
