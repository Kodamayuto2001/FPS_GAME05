using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController playerController;
    [SerializeField]
    private float speed = 12f;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float gravity = 9.81f;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float groundDistance = 1.0f;
    [SerializeField]
    private LayerMask groundMask;
    #region Flag
    private bool isGrounded;
    #endregion //!Flag
    private float x;
    private float z;
    private Vector3 move;
    private Vector3 velocity;
    //基本的に関数内で変数宣言は行うな
    //パフォーマンス低下につながる

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        move = transform.right * x + transform.forward * z;
        playerController.Move(move * speed * Time.deltaTime);
        FuncAnimator();

        FuncGravity();
    }
    void FuncAnimator()
    {
        if (move.magnitude > 0.2f)
        {
            animator.SetFloat("Speed", move.magnitude);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
    }
    void FuncGravity()
    {
        //Apply gravity
        velocity.y = velocity.y - (gravity * Time.deltaTime);

        playerController.Move(velocity * Time.deltaTime);
    }
}
