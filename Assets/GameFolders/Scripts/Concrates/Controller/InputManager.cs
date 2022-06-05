using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kajujam.Concrates.Controller
{
    public class InputManager : MonoBehaviour
    {
        private static InputManager instance;
        public static InputManager Instance
        {
            get { return instance; }
        }



        private PlayerControls playerControls;

        private void Awake()
        {
            if (instance != null && instance != null)
            {
                Destroy(this.gameObject);
            }
            else
            {
                instance = this;
            }
            playerControls = new PlayerControls();
            //Cursor.visible = false;
        }
        private void OnEnable()
        {
            playerControls.Enable();
        }
        private void OnDisable()
        {
            playerControls.Disable();
        }

        public Vector2 GetPLayerMovement()
        {
            return playerControls.Player.Movement.ReadValue<Vector2>();
        }
        public Vector2 GetMouseDelta()
        {
            return playerControls.Player.Look.ReadValue<Vector2>();
        }
        public bool GetMouseLeftClick()
        {
            return playerControls.Player.Shoot.IsPressed();
        }
    }
}
