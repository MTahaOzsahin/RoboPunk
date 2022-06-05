using Kajujam.Concrates.Combats;
using Kajujam.Concrates.Controller;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    Button bL, bR;
    [SerializeField]
    GameObject player;

    [SerializeField]
    TextMeshProUGUI blText, brText;

    Health playerHealth;

    //          Power ups list
    //bL.onClick.AddListener(() => fireRate(-0.3f));
    //bL.onClick.AddListener(() => SpeedSet(-0.3f));
    //bL.onClick.AddListener(() => BarrelSet(PlayerController.BarrelCount.two));
    //bL.onClick.AddListener(() => setHealth(3));
    //bL.onClick.AddListener(() => setXpGain(3));
    //bL.onClick.AddListener(() => SetDmg(3));
    //bL.onClick.AddListener(() => setBulletSize(3));  Çýkarýldý...

    //bR.onClick.AddListener(() => fireRate(-0.3f));
    //bR.onClick.AddListener(() => SpeedSet(-0.3f));
    //bR.onClick.AddListener(() => BarrelSet(PlayerController.BarrelCount.two));
    //bR.onClick.AddListener(() => setHealth(3));
    //bR.onClick.AddListener(() => setXpGain(3));
    //bR.onClick.AddListener(() => SetDmg(3));
    //bR.onClick.AddListener(() => setBulletSize(3));    Çýkarýldý...

    private void Start()
    {
        playerHealth = player.GetComponent<Health>();
    }

    private void OnEnable()
    {
        int caseNum = Random.Range(0, 9);
       
        PlayerFpsController.Instance.shoot = false;
        Time.timeScale = 0;
        
        switch (caseNum)
        {
            case 0:
                blText.text = "Fire Rate -0.3 \n\n Movement Speed -1";
                brText.text = "Dmg +3 \n\n Health -3";
                bL.onClick.AddListener(() => FireRate(-0.3f));
                bL.onClick.AddListener(() => SpeedSet(-1f));
                bL.onClick.AddListener(SetGameSpeed);// her case de olmali
                bL.onClick.AddListener(DisableSelf);// her case de olmali 

                bR.onClick.AddListener(() => SetDmg(3));
                bR.onClick.AddListener(() => SetHealth(-3));
                bR.onClick.AddListener(SetGameSpeed);// her case de olmali
                bR.onClick.AddListener(DisableSelf);// her case de olmali 
                break;
            case 1:
                blText.text = "Two Barrel \n\n Movement Speed -1";
                brText.text = "XpGain +3 \n\n Movement Speed -1";
                bL.onClick.AddListener(() => BarrelSet(PlayerFpsController.BarrelCount.two));
                bL.onClick.AddListener(() => SpeedSet(-1f));
                bL.onClick.AddListener(SetGameSpeed);// her case de olmali
                bL.onClick.AddListener(DisableSelf);// her case de olmali 

                bR.onClick.AddListener(() => SetXpGain(3));
                bR.onClick.AddListener(() => SpeedSet(-1f));
                bR.onClick.AddListener(SetGameSpeed);// her case de olmali
                bR.onClick.AddListener(DisableSelf);// her case de olmali 
                break;
            case 2:
                blText.text = "Movement Speed +1 \n\n Fire Rate +0.3";
                brText.text = "Health +3 \n\n XpGain -2";
                bL.onClick.AddListener(() => SpeedSet(1f));
                bL.onClick.AddListener(() => FireRate(0.3f));
                bL.onClick.AddListener(SetGameSpeed);// her case de olmali
                bL.onClick.AddListener(DisableSelf);// her case de olmali 

                bR.onClick.AddListener(() => SetHealth(3));
                bR.onClick.AddListener(() => SetXpGain(-2));
                bR.onClick.AddListener(SetGameSpeed);// her case de olmali
                bR.onClick.AddListener(DisableSelf);// her case de olmali 
                break;
            case 3:
                blText.text = "Three Barrel \n\n XpGain -2";
                brText.text = "Fire Rate -0.3 \n\n One Barrel";
                bL.onClick.AddListener(() => BarrelSet(PlayerFpsController.BarrelCount.three));
                bL.onClick.AddListener(() => SetXpGain(-2));
                bL.onClick.AddListener(SetGameSpeed);// her case de olmali
                bL.onClick.AddListener(DisableSelf);// her case de olmali 

                bR.onClick.AddListener(() => FireRate(-0.3f));
                bR.onClick.AddListener(() => BarrelSet(PlayerFpsController.BarrelCount.one));
                bR.onClick.AddListener(SetGameSpeed);// her case de olmali
                bR.onClick.AddListener(DisableSelf);// her case de olmali 
                break;
            case 4:
                blText.text = "XpGain +2 \n\n Movement Speed -1";
                brText.text = "Dmg +3 \n\n Fire Rate +0.3";
                bL.onClick.AddListener(() => SetXpGain(2));
                bL.onClick.AddListener(() => SpeedSet(-1f));
                bL.onClick.AddListener(SetGameSpeed);// her case de olmali
                bL.onClick.AddListener(DisableSelf);// her case de olmali

                bR.onClick.AddListener(() => SetDmg(3));
                bR.onClick.AddListener(() => FireRate(0.3f));
                bR.onClick.AddListener(SetGameSpeed);// her case de olmali
                bR.onClick.AddListener(DisableSelf);// her case de olmali 
                break;
            case 5:
                blText.text = "Health +3 \n\n Movement Speed -1";
                brText.text = "Two Barrel \n\n Fire Rate +0.3";
                bL.onClick.AddListener(() => SetHealth(3));
                bL.onClick.AddListener(() => SpeedSet(-1f));
                bL.onClick.AddListener(SetGameSpeed);// her case de olmali
                bL.onClick.AddListener(DisableSelf);// her case de olmali 

                bR.onClick.AddListener(() => BarrelSet(PlayerFpsController.BarrelCount.two));
                bR.onClick.AddListener(() => FireRate(0.3f));
                bR.onClick.AddListener(SetGameSpeed);// her case de olmali
                bR.onClick.AddListener(DisableSelf);// her case de olmali 
                break;
            case 6:
                blText.text = "Dmg +3 \n\n XpGain -2";
                brText.text = "Three Barrel \n\n Health -3";
                bL.onClick.AddListener(() => SetDmg(3));
                bL.onClick.AddListener(() => SetXpGain(-2));
                bL.onClick.AddListener(SetGameSpeed);// her case de olmali
                bL.onClick.AddListener(DisableSelf);// her case de olmali 

                bR.onClick.AddListener(() => BarrelSet(PlayerFpsController.BarrelCount.three));
                bR.onClick.AddListener(() => SetHealth(-3));
                bR.onClick.AddListener(SetGameSpeed);// her case de olmali
                bR.onClick.AddListener(DisableSelf);// her case de olmali 
                break;
            case 7:
                blText.text = "Fire Rate -0.3 \n\n XpGain -2";
                brText.text = "Health +3 \n\n One Barrel";
                bL.onClick.AddListener(() => FireRate(-0.3f));
                bL.onClick.AddListener(() => SetXpGain(-2));
                bL.onClick.AddListener(SetGameSpeed);// her case de olmali
                bL.onClick.AddListener(DisableSelf);// her case de olmali 

                bR.onClick.AddListener(() => SetHealth(3));
                bR.onClick.AddListener(() => BarrelSet(PlayerFpsController.BarrelCount.one));
                bR.onClick.AddListener(SetGameSpeed);// her case de olmali
                bR.onClick.AddListener(DisableSelf);// her case de olmali 
                break;
            case 8:
                blText.text = "Fire Rate -0.3 \n\n Dmg - 3";
                brText.text = "Two Barrel \n\n XpGain -2";
                bL.onClick.AddListener(() => FireRate(-0.3f));
                bL.onClick.AddListener(() => SetDmg(-3));
                bL.onClick.AddListener(SetGameSpeed);// her case de olmali
                bL.onClick.AddListener(DisableSelf);// her case de olmali 

                bR.onClick.AddListener(() => BarrelSet(PlayerFpsController.BarrelCount.two));
                bR.onClick.AddListener(() => SetXpGain(-2));
                bR.onClick.AddListener(SetGameSpeed);// her case de olmali
                bR.onClick.AddListener(DisableSelf);// her case de olmali 
                break;
            default:
                break;
        }
    }

    private void OnDisable()
    {
        PlayerFpsController.Instance.shoot = true;
        Time.timeScale = 1;

        bR.onClick.RemoveAllListeners();
        bL.onClick.RemoveAllListeners();
    }

    public void FireRate(float fireRate)
    {
        if (fireRate < 0)
        {
            if (PlayerFpsController.Instance.fireRate - Mathf.Abs(fireRate) <= 0.1f)
            {
                return;
            }
        }
        PlayerFpsController.Instance.fireRate += fireRate;
    }

    public void SpeedSet(float moveSpeed)
    {
        if (PlayerFpsController.Instance.moveSpeed <= Mathf.Abs(moveSpeed))
        {
            return;
        }
        PlayerFpsController.Instance.moveSpeed += moveSpeed;
    }

    public void BarrelSet(PlayerFpsController.BarrelCount barrel)
    {
        PlayerFpsController.Instance.barrelCount = barrel;
    }

    public void SetHealth(int health)
    {
        if (health < 0)
        {
            if (playerHealth.currentHealth < Mathf.Abs(health))
            {
                return;
            }
        }
        playerHealth.currentHealth += health;

        if (playerHealth.currentHealth > playerHealth.maxHealth)
        {
            playerHealth.maxHealth = playerHealth.currentHealth;
            PlayerFpsController.Instance.sliderMax();
        }
    }

    public void SetXpGain(float xpGain)
    {
        if (xpGain < 0)
        {
            if (PlayerFpsController.Instance.xpGain < Mathf.Abs(xpGain))
            {
                return;
            }
        }
        PlayerFpsController.Instance.xpGain += xpGain;
    }
    public void SetGameSpeed()
    {
        Time.timeScale = 1f;
    }

    public void DisableSelf()
    {
        gameObject.SetActive(false);
    }

    public void SetDmg(int dmg)
    {
        if (dmg < 0)
        {
            if (ObjectPool.SharedInstance.pooledObjects[0].GetComponent<Damage>().damage < Mathf.Abs(dmg))
            {
                return;
            }
        }
        foreach (var item in ObjectPool.SharedInstance.pooledObjects)
        {
            item.GetComponent<Damage>().damage += dmg;
        }
    }

}
