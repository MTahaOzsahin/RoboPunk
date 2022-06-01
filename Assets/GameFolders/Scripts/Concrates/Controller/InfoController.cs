using Kajujam.Concrates.Combats;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Kajujam.Concrates.Controller
{
    public class InfoController : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI moveText, fireText, damageText, barrelText, xpGainText, currentExpText,nextLevelText;

        float playerFireRate;


        [SerializeField] GameObject bulletGameObject;
        


        private void Update()
        {
            ShowInfo();
        }

        void ShowInfo()
        {
            playerFireRate = PlayerController.Instance.fireRate;
            playerFireRate = Mathf.Round(playerFireRate * 100.0f) * 0.01f;


            moveText.text = PlayerController.Instance.moveSpeed.ToString();
            fireText.text = playerFireRate.ToString();
            damageText.text = objectPool.SharedInstance.pooledObjects[0].GetComponent<Damage>().damage.ToString();
            barrelText.text = PlayerController.Instance.barrelCount.ToString();
            xpGainText.text = PlayerController.Instance.xpGain.ToString();
            currentExpText.text = PlayerController.Instance.exp.ToString();
            nextLevelText.text = PlayerController.Instance.experienceToNextLevel.ToString();
        }
    }
}