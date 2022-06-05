using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kajujam.Concrates.Combats;
using Kajujam.Concrates.Controller;


public class PlayerAnimController : MonoBehaviour
{
    public Animator playerAnimator;
    Health health;


    InputManager inputManager;


    

    void Start()
    {
        health = PlayerController.Instance.gameObject.GetComponent<Health>();
        inputManager = InputManager.Instance;
    }


    void Update()
    {
        if (inputManager.GetPLayerMovement().x != 0 || inputManager.GetPLayerMovement().y != 0)
        {
            playerAnimator.SetBool("shootBool", true);
        }
        else
        {
            playerAnimator.SetBool("shootBool", false);
        }
        if (health.currentHealth <= 0)
        {
            playerAnimator.SetBool("deathBool", true);
        }
        if (inputManager.GetMouseLeftClick())
        {
            playerAnimator.SetBool("shootBool", true);
        }
    }

    
}
