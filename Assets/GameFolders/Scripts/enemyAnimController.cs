using Kajujam.Concrates.Combats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kajujam.Concrates.Controller;

public class enemyAnimController : MonoBehaviour
{
    public Animator enemyAnimator;
    Health healt;
    [SerializeField]
    ParticleSystem particle;




    void Start()
    {
        healt = GetComponent<Health>();
    }


    void Update()
    {
        if (healt.IsDead)
        {
            enemyAnimator.SetBool("deathBool", true);
            if (particle.isStopped)
            {
                particle.Play();
            }

        }

        if (enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Enemy1Death"))
        {
            if (enemyAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                GetComponent<EnemyController>().OnEnemyDead();

            }
        }
    }
}
