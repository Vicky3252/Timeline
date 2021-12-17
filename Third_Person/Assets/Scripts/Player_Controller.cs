using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public float jumpheight;

    public float gravity=-9.8f;
    Vector3 velocity;

    public Transform groundCheck;
    public float sphereradius;
    public LayerMask groundMask;

    bool isGrounded;
    public NewPlayerActions ip;
    public InputAction iActions;

    // Start is called before the first frame update
    private void Start()
    {
        ip = new NewPlayerActions();

        ip.Player.Jump.performed += Jump;
        //ip.Player.Jump.Enable();
        ip.Player.Move.Enable();
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereradius, groundMask);

        if(isGrounded && velocity.y<0)
        {
            velocity.y = -2f;
        }
        //  float x = Input.GetAxis("Horizontal");
        //   float z = Input.GetAxis("Vertical");

        //  Vector3 move = transform.right * x + transform.forward * z;
        //   controller.Move(move * speed * Time.deltaTime);

        Vector3 jump = transform.up;
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        //controller.Move(velocity * Time.deltaTime);


        //Debug.Log(ip.Player.Move.ReadValue<Vector2>());
        Vector2 ipmove = ip.Player.Move.ReadValue<Vector2>();
        transform.position += new Vector3(ipmove.x * speed * Time.deltaTime, 0, ipmove.y * speed * Time.deltaTime);
    }
}
