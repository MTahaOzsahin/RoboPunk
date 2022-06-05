using Kajujam.Concrates.Combats;
using Kajujam.Concrates.ExtensionMethods;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kajujam.Concrates.Controller
{
    public class EnemyController : MonoBehaviour
    {
        Health health;
        Damage damage;
        



        [SerializeField] AudioClip deadClip;
        public static event System.Action<AudioClip> OnEnemyDeadSound;



        private void Awake()
        {
            health = GetComponent<Health>();
            damage = GetComponent<Damage>();
        }
        private void OnEnable()
        {
            health.OnDead += () => OnEnemyDeadSound.Invoke(deadClip);
            health.OnDead += XpGainOnDead;
        }

        private void XpGainOnDead()
        {
            //PlayerController.Instance.exp += PlayerController.Instance.xpGain;
            PlayerFpsController.Instance.exp += PlayerFpsController.Instance.xpGain;

        }

        public void OnEnemyDead()
        {
            
            this.gameObject.SetActive(false);
        }
        private void Update()
        {
            PlayerFollow();
        }


        void PlayerFollow()
        {
            //targetPosition = transform.position + (target.Position - transform.position).normalized * 1000.0
            //Vector3 dif = new Vector3(playerGameObject.transform.position.x, transform.position.y, playerGameObject.transform.position.z);

            if (GetComponent<Health>().currentHealth != 0)
            {
                GetComponent<Collider>().enabled = true;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                Vector3 targetP = transform.position + (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized * 100f;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                transform.position = Vector3.MoveTowards(transform.position, targetP, 5f * Time.deltaTime);
                transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
            }
            else
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<Collider>().enabled = false;
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.HasHitPlayer())
            {
                health.TakingHit(damage);
            }
            if (collision.HasHitBullet())
            {
                health.TakingHit(damage);
            }
        }


    }
}
