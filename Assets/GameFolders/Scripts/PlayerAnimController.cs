using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kajujam.Concrates.Combats;
using Kajujam.Concrates.ExtensionMethods;
using Kajujam.Abstracts.Inputs;
using Kajujam.Concrates.Inputs;
using Kajujam.Concrates.Controller;

public class PlayerAnimController : MonoBehaviour
{
    IPlayerInputs pcInputs;
    public Animator playerAnimator;
    float horizontal;
    float vertical;
    Health health;


    
    void Start()
    {
        pcInputs = new PCInputs();
        health = PlayerController.Instance.gameObject.GetComponent<Health>();
    }


    void Update()
    {
        GetAxis();
        if (horizontal != 0 || vertical != 0)
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

        if (Input.GetMouseButton(0))
        {
            playerAnimator.SetBool("shootBool", true);
        }
        else if (Input.GetMouseButton(1))
        {
            playerAnimator.SetBool("shootBool", true);
        }
    }

    void GetAxis()
    {
        horizontal = pcInputs.Horizontal;
        vertical = pcInputs.Vertical;
    }
}
