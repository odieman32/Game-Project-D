using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MovementStateManager : MonoBehaviour
{
    public float currentMoveSpeed;
    public float walkSpeed = 3, walkBackSpeed = 2;
    public float runSpeed = 7, runBackSpeed = 5;
    public float crouchSpeed = 2, crouchBackSpeed = 1;

    [HideInInspector] public Vector3 dir;
    [HideInInspector] public float hzInput, vInput;
    CharacterController controller;

    [SerializeField] float groundYoffset;
    [SerializeField] LayerMask groundMask;
    Vector3 spherePos;

    [SerializeField] float gravity = -9.81f;
    Vector3 velocity;

    MovementBaseState currentState;

    public IdleState Idle = new IdleState();
    public WalkState Walk = new WalkState();
    public CrouchState Crouch = new CrouchState();
    public RunState Run = new RunState();

    [HideInInspector] public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        SwitchState(Idle);
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetDirectionAndMove();
        Gravity();

        currentState.UpdateState(this);

        animator.SetFloat("hzInput", hzInput);
        animator.SetFloat("vInput", vInput);
    }

    public void SwitchState(MovementBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    void GetDirectionAndMove ()
    {
        hzInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        dir = transform.forward * vInput + transform.right * hzInput;

        controller.Move(dir.normalized * currentMoveSpeed * Time.deltaTime);
    }

    bool IsGrounded ()
    {
        spherePos = new Vector3(transform.position.x, transform.position.y - groundYoffset, transform.position.z);
        if(Physics.CheckSphere(spherePos, controller.radius -0.05f, groundMask)) 
            return true;
        else
            return false;
    }

    void Gravity ()
    {
        if (!IsGrounded()) 
            velocity.y += gravity * Time.deltaTime;
        else if (velocity.y < 0) 
            velocity.y = -2;

        controller.Move(velocity * Time.deltaTime);
    }

    //private void OnDrawGizmos()
    //{
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(spherePos, controller.radius - 0.05f);
    //}
}


//https://www.youtube.com/@gaddgames by Gadd Games