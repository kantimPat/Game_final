using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GatherInput : MonoBehaviour
{
    public Controls controls;
    public float value_x;
    public bool jump_input;
    public float jump_force = 5;
    public bool try_atk;

    private void Awake()
    {
        controls = new Controls();
    }

    private void OnEnable()
    {
        controls.Player.Move.performed += StartMove;
        controls.Player.Move.canceled += StopMove;
        controls.Player.Jump.performed += JumpStart;
        controls.Player.Jump.canceled += JumpStop;
        controls.Player.Attack.performed += TryToAtk;
        controls.Player.Attack.canceled += StopTryToAtk;
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Move.performed -= StartMove;
        controls.Player.Move.canceled -= StopMove;
        controls.Player.Jump.performed -= JumpStart;
        controls.Player.Jump.canceled -= JumpStop;
        controls.Player.Attack.performed -= TryToAtk;
        controls.Player.Attack.canceled -= StopTryToAtk;
        controls.Player.Disable();
        
    }
    public void DisableControl()
    {
        controls.Player.Move.performed -= StartMove;
        controls.Player.Move.canceled -= StopMove;
        controls.Player.Jump.performed -= JumpStart;
        controls.Player.Jump.canceled -= JumpStop;
        controls.Player.Disable();
        value_x = 0 ;
        
    }
    private void StartMove(InputAction.CallbackContext contxt)
    {
        value_x = contxt.ReadValue<float>();
    }
    
    private void StopMove(InputAction.CallbackContext contxt)
    {
        value_x = 0;
    }

    private void JumpStart(InputAction.CallbackContext contxt)
    {
        jump_input = true;
    }
    
    private void JumpStop(InputAction.CallbackContext contxt)
    {
        jump_input = false;
    }

    private void TryToAtk(InputAction.CallbackContext cxt)
    {
        try_atk = true;
    }
    private void StopTryToAtk(InputAction.CallbackContext ctx)
    {
        try_atk = false;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
