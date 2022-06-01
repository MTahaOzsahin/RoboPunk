using Kajujam.Concrates.Controller;
using System.Collections;
using Kajujam.Concrates.ExtensionMethods;
using System.Collections.Generic;
using UnityEngine;
using Kajujam.Concrates.Combats;

public class bullet : MonoBehaviour
{

    Health health;
    Damage damage;

    bool coroutineIsFinished = true;
    public float moveSpeed = 5f;
    public float deadRate = 5f;

   
    private void Awake()
    {
        health = GetComponent<Health>();
        damage = GetComponent<Damage>();
    }
    
    void Update()
    {
        Fire();
        //transform.localPosition += transform.forward * moveSpeed * Time.deltaTime;
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
        //GetPlayerLocation();
        coroutineIsFinished = false;

        yield return new WaitForSeconds(deadRate); //will wait 5seconds before continuing

        gameObject.SetActive(false);
        coroutineIsFinished = true;
       

    }
    void GetPlayerLocation()
    {
        if (Input.GetMouseButton(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                if (hitInfo.collider != null)
                {
                    Vector3 newP = new Vector3(hitInfo.point.x, transform.position.y, hitInfo.point.z);
                    transform.LookAt(newP);


                }
            }

        }
    }
    void Fire()
    {
        transform.localPosition += transform.forward * moveSpeed *10 * Time.deltaTime;
    }

    

}
