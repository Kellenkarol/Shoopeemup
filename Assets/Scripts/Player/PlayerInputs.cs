using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace Player
{
    public class PlayerInputs : MonoBehaviour
    {
        private InputMap inputActions;

        private Vector2 movementDirection;

        private bool shootButtonPressed = false;
        private bool shieldButtonPressed = false;

        private void Awake()
        {
            inputActions = new InputMap();

            inputActions.Player.Movement.performed += ctx => movementDirection = ctx.ReadValue<Vector2>();
            inputActions.Player.Movement.canceled += ctx => movementDirection = Vector2.zero;

            inputActions.Player.Shoot.performed += ctx => RegisterShoot(ctx);
            inputActions.Player.Shoot.canceled += ctx => RegisterShoot(ctx);

            inputActions.Player.Shield.performed += _ => RegisterShield();
        }

        private void OnEnable()
        {
            inputActions.Enable();
        }
        private void OnDisable()
        {
            inputActions.Disable();
        }

        private void Update()
        {
            Debug.Log(movementDirection);
        }

        private void RegisterShoot(CallbackContext ctx)
        {
            if (ctx.performed) shootButtonPressed = true;
            else if (ctx.canceled) shootButtonPressed = false;
        }

        private void RegisterShield()
        {
            shieldButtonPressed = true;
        }

        public Vector2 GetMovementDirection()
        {
            return movementDirection;
        }

        public bool GetShootButtonPressed()
        {
            return shootButtonPressed;
        }

        public bool GetShieldButtonPressed()
        {
            if (shieldButtonPressed)
            {
                shieldButtonPressed = false;
                return true;
            }

            return false;
        }
    }
}
