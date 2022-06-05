using Kajujam.Concrates.Combats;
using Kajujam.Concrates.ExtensionMethods;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Kajujam.Concrates.Controller
{
    public class InfoController : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI moveText, fireText, damageText, barrelText, xpGainText, currentExpText,nextLevelText,currentHealthText;

        float playerFireRate;


        [SerializeField] GameObject bulletGameObject;


        private void Awake()
        {
            
        }
        private void Update()
        {
            ShowInfo();
        }

        void ShowInfo()
        {
            playerFireRate = PlayerFpsController.Instance.fireRate;
            playerFireRate = Mathf.Round(playerFireRate * 100.0f) * 0.01f;


            moveText.text = PlayerFpsController.Instance.moveSpeed.ToString();
            fireText.text = playerFireRate.ToString();
            damageText.text = ObjectPool.SharedInstance.pooledObjects[0].GetComponent<Damage>().damage.ToString();
            barrelText.text = PlayerFpsController.Instance.barrelCount.ToString().ToTitleCase();
            xpGainText.text = PlayerFpsController.Instance.xpGain.ToString();
            currentExpText.text = PlayerFpsController.Instance.exp.ToString();
            nextLevelText.text = PlayerFpsController.Instance.experienceToNextLevel.ToString();
            currentHealthText.text = PlayerFpsController.Instance.GetComponent<Health>().currentHealth.ToString();
        }
    }
}
