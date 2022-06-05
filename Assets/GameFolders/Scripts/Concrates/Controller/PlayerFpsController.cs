using Kajujam.Concrates.Combats;
using Kajujam.Concrates.ExtensionMethods;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Kajujam.Concrates.Controller
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerFpsController : Singleton<PlayerFpsController>
    {

        Health health;
        Damage damage;
        ObjectPool objPool;
        public float exp = 0;
        public float fireRate = 1f;
        public float xpGain = 10f;
        float timer = 0f;
        public bool shoot = true;
        float playerLevel;
        float experience;
        public float experienceToNextLevel = 100;
        public Slider slider;


        private CharacterController characterController;
        private Vector3 playerVelocity;
        //private bool groundedPlayer;
        [SerializeField]
        private float playerSpeed = 10f;
        //[SerializeField]
        //private float jumpHeight = 1.0f;
        [SerializeField]
        private float gravityValue = -9.81f;

        private InputManager inputManager;
        private Transform cameraTransform;










        float turnSmoothVelocity;
        //[SerializeField] Transform cam;

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
       
        private void Awake()
        {
            //pcInputs = new PCInputs();
            health = GetComponent<Health>();
            damage = GetComponent<Damage>();
            objPool = GetComponent<ObjectPool>();
        }

        private void Start()
        {
            sliderMax();
            setSlider();

            characterController = GetComponent<CharacterController>();
            inputManager = InputManager.Instance;
            cameraTransform = Camera.main.transform;
        }
        private void OnEnable()
        {
            health.OnDead += () => OnPlayerDead(playerDeadClip);
        }
        private void FixedUpdate()
        {
            LevelSystem();
        }
        private void Update()
        {
            PlayerControlsInputSystem();
            FireBullet();
            OnPlayerDeadLoadScene();
        }
        public void LevelSystem()
        {
            experience = exp;
            if (experience >= experienceToNextLevel)
            {
                playerLevel++;
                experienceToNextLevel += 150;
                uiElement.SetActive(true);
            }
        }
       
        public void PlayerControlsInputSystem()
        {
            
            if ( playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            Vector2 movement = inputManager.GetPLayerMovement();
            Vector3 move = new Vector3(movement.x, 0f, movement.y);
            move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
            move.y = 0f;
            characterController.Move(move * Time.deltaTime * playerSpeed);
            transform.SetPositionAndRotation(transform.position, cameraTransform.rotation);


            playerVelocity.y += gravityValue * Time.deltaTime;
            characterController.Move(playerVelocity * Time.deltaTime);

            Cursor.lockState = CursorLockMode.Confined; // keep confined in the game window
            
            
        }
        public void FireBullet()
        {
            timer += Time.deltaTime;
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
                    if (inputManager.GetMouseLeftClick() && shoot)
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
                    if (inputManager.GetMouseLeftClick() && shoot)
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
                    if (inputManager.GetMouseLeftClick() && shoot)
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
