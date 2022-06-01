using Kajujam.Abstracts.Inputs;
using Kajujam.Concrates.Combats;
using Kajujam.Concrates.ExtensionMethods;
using Kajujam.Concrates.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Kajujam.Concrates.Controller
{
    public class PlayerController : singleton<PlayerController>
    {
        IPlayerInputs pcInputs;
        Health health;
        Damage damage;
        objectPool objPool;
        public float exp = 0;
        public float fireRate = 1f;
        public float xpGain = 10f;
        float timer = 0f;
        public bool shoot = true;
        float playerLevel;
        float experience;
        public  float experienceToNextLevel = 100;

        public Slider slider;

        
        

        public enum BarrelCount { one, two, three }
        public BarrelCount barrelCount;
        [SerializeField] GameObject playerBarrelPositionMiddle;
        [SerializeField] GameObject playerBarrelPositionLeft;
        [SerializeField] GameObject playerBarrelPositionRight;
        [SerializeField] GameObject uiElement;


        [SerializeField] AudioClip bulletClip;
        [SerializeField] AudioClip playerDeadClip;
        public static event System.Action<AudioClip> OnBulletFire;
        public static event System.Action<AudioClip> OnPlayerDead;



        [SerializeField] public float moveSpeed;
        float horizontal;
        float vertical;

        private void Awake()
        {
            pcInputs = new PCInputs();
            health = GetComponent<Health>();
            damage = GetComponent<Damage>();
            objPool = GetComponent<objectPool>();

        }

        private void Start()
        {
            sliderMax();
            setSlider();
        }
        private void OnEnable()
        {
            health.OnDead += () => OnPlayerDead(playerDeadClip);
        }
        private void FixedUpdate()
        {
            Movement(horizontal);
            LevelSystem();
        }
        private void Update()
        {
            timer += Time.deltaTime;
            Rotatiton();
            FireBullet();
            OnPlayerDeadLoadScene();
        }
        public void LevelSystem()
        {
            experience = exp;
            if (experience >= experienceToNextLevel)
            {
                playerLevel++;
                experienceToNextLevel += 50;
                uiElement.SetActive(true);
            }
        }
        void GetAxis()
        {
            horizontal = pcInputs.Horizontal;
            vertical = pcInputs.Vertical;
        }
        public void Movement(float horizontal)
        {
            GetAxis();
            if (!health.IsDead)
            {
                transform.position += Vector3.right * horizontal * Time.deltaTime * moveSpeed;
                transform.position += Vector3.forward * vertical * Time.deltaTime * moveSpeed;
            } 
        }

        public void Rotatiton()
        {
            if (Time.timeScale > 0)
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
            //if (Time.timeScale > 0)
            //{
            //    Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            //    RaycastHit hitInfo;
            //    if (Physics.Raycast(rayOrigin, out hitInfo))
            //    {
            //        if (hitInfo.collider != null)
            //        {
            //            Vector3 newP = new Vector3(Input.mousePosition.x,transform.position.y,Input.mousePosition.z);
            //            transform.LookAt(Input.mousePosition);
            //        }
            //    }


            //}

        }
        public void FireBullet()
        {
            GameObject bullets;
            GameObject bullets2;
            GameObject bullets3;

            if (timer > fireRate)
            {
                shoot = true;
            }
            else
            {
                shoot = false;
            }


            switch (barrelCount)
            {
                case BarrelCount.one:
                    if (Input.GetMouseButton(0) && shoot)
                    {
                        bullets = objPool.GetPooledObject();
                        bullets.transform.position = playerBarrelPositionMiddle.transform.position;
                        bullets.transform.rotation = playerBarrelPositionMiddle.transform.rotation;
                        bullets.SetActive(true);
                        OnBulletFire?.Invoke(bulletClip);
                        timer = 0;
                    }
                    break;
                case BarrelCount.two:
                    if (Input.GetMouseButton(0) && shoot)
                    {
                        bullets = objPool.GetPooledObject();

                        bullets.transform.position = playerBarrelPositionRight.transform.position;
                        bullets.transform.rotation = playerBarrelPositionRight.transform.rotation;
                        bullets.SetActive(true);
                        bullets2 = objPool.GetPooledObject();
                        bullets2.transform.position = playerBarrelPositionLeft.transform.position;
                        bullets2.transform.rotation = playerBarrelPositionLeft.transform.rotation;
                        bullets2.SetActive(true);
                        OnBulletFire?.Invoke(bulletClip);
                        timer = 0;
                    }
                    break;
                case BarrelCount.three:
                    if (Input.GetMouseButton(0) && shoot)
                    {
                        bullets = objPool.GetPooledObject();
                        bullets.transform.position = playerBarrelPositionMiddle.transform.position;
                        bullets.transform.rotation = playerBarrelPositionMiddle.transform.rotation;
                        bullets.SetActive(true);
                        bullets2 = objPool.GetPooledObject();
                        bullets2.transform.position = playerBarrelPositionLeft.transform.position;
                        bullets2.transform.rotation = playerBarrelPositionLeft.transform.rotation;
                        bullets2.SetActive(true);
                        bullets3 = objPool.GetPooledObject();
                        bullets3.transform.position = playerBarrelPositionRight.transform.position;
                        bullets3.transform.rotation = playerBarrelPositionRight.transform.rotation;
                        bullets3.SetActive(true);
                        OnBulletFire?.Invoke(bulletClip);
                        timer = 0;
                    }
                    break;
                default:
                    break;
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.HasHitEnemy())
            {
                health.TakingHit(collision.gameObject.GetComponent<Damage>());
                setSlider();
            }

        }

        public void sliderMax()
        {
            slider.maxValue = health.maxHealth;
        }

        public void setSlider()
        {
            slider.value = health.currentHealth;
        }
        public void OnPlayerDeadLoadScene()
        {
            if (health.IsDead)
            {
                StartCoroutine(OnPlayerDeadAction());
            }

        }
        public IEnumerator OnPlayerDeadAction()
        {
            int buildIndex = SceneManager.GetActiveScene().buildIndex;

            yield return new WaitForSeconds(3f);

            SceneManager.LoadScene(buildIndex);
        }



    }
}
