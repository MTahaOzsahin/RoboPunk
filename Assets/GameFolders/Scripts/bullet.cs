using Kajujam.Concrates.Controller;
using System.Collections;
using Kajujam.Concrates.ExtensionMethods;
using System.Collections.Generic;
using UnityEngine;
using Kajujam.Concrates.Combats;

public class Bullet : MonoBehaviour
{

   

    bool coroutineIsFinished = true;
    public float moveSpeed = 5f;
    public float deadRate = 5f;

   
    private void Awake()
    {
       
    }
    
    void Update()
    {
        Fire();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.HasHitEnemy())
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        
        if (coroutineIsFinished)
        {
            StartCoroutine("Deactivate");
        }
        else
        {

            //If the coroutine is still going on we stop it
            
            StopCoroutine("Deactivate");

            //Then restart it

            StartCoroutine("Deactivate");

        }

        //DOVirtual.DelayedCall(6f, () => gameObject.SetActive(false));
    }

    

    IEnumerator Deactivate()

    {
        coroutineIsFinished = false;

        yield return new WaitForSeconds(deadRate); //will wait 5seconds before continuing

        gameObject.SetActive(false);
        coroutineIsFinished = true;
       

    }
    void Fire()
    {
        transform.localPosition += transform.forward * moveSpeed *10 * Time.deltaTime;
    }

    

}
