using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement2 : MonoBehaviour
{
    #region SerializeField
    [SerializeField]
    private CharacterController playerController;
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private Animator animator;
    #endregion //!SerializeField


    private float x;
    private float z;

    private Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FuncMove();
        FuncAnimator();
        FuncGravity();
    }

    void FuncMove()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        move = transform.right * x + transform.forward * z;
        playerController.Move(move * speed * Time.deltaTime);
    }
    void FuncAnimator()
    {
        if (move.magnitude > 0.1f)
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
        
    }
}
