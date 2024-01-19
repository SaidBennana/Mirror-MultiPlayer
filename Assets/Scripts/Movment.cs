using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Movment : MonoBehaviour
{
    [SerializeField] CharacterController character;

    [SerializeField] float SpeedMove = 2;
    [SerializeField] float JumpHight = 2;
    private float MoveX, MoveY;

    private Vector3 movement;
    // Player Look to camera dirction
    private Camera Cam;

    // gravity and jump
    [SerializeField] float gravity = -9.81f;
    private Vector3 velocity;

    [SerializeField] bool isGrounded;
    [SerializeField] Transform ChackPoint;
    [SerializeField] LayerMask GroundLayer;

    private void Start()
    {
        Cam = Camera.main;
    }




    void Update()
    {
        isGrounded = Physics.CheckSphere(ChackPoint.position, 0.2f, GroundLayer);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        MoveX = Input.GetAxisRaw("Horizontal");
        MoveY = Input.GetAxisRaw("Vertical");

        movement = new Vector3(MoveX, 0, MoveY).normalized;

        if (movement.magnitude >= 0.1f)
        {

            float angle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + Cam.transform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDir = Quaternion.Euler(0, angle, 0) * Vector3.forward;

            character.Move(moveDir * SpeedMove * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = math.sqrt(JumpHight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        character.Move(velocity * Time.deltaTime);
    }
}
