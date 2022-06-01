using Kajujam.Concrates.Combats;
using Kajujam.Concrates.Controller;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class buttonController : MonoBehaviour
{
    [SerializeField]
    Button bL, bR;
    [SerializeField]
    GameObject player;

    [SerializeField]
    TextMeshProUGUI blText, brText;

    Health playerHealth;

    private void Start()
    {
        playerHealth = player.GetComponent<Health>();
    }

    private void OnEnable()
    {
        //int caseNum = Random.Range(0, 9); 
        int caseNum = 0;
        PlayerController.Instance.shoot = false;
        Time.timeScale = 0;
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

        switch (caseNum)
        {
            case 0:
                blText.text = "Fire Rate -0.3 \n\n Movement Speed -1";
                brText.text = "Dmg +3 \n\n Health -3";
                bL.onClick.AddListener(() => fireRate(-0.3f));
                bL.onClick.AddListener(() => SpeedSet(-1f));
                bL.onClick.AddListener(setGameSpeed);// her case de olmali
                bL.onClick.AddListener(DisableSelf);// her case de olmali 

               


                bR.onClick.AddListener(() => SetDmg(3));
                bR.onClick.AddListener(() => setHealth(-3));
                bR.onClick.AddListener(setGameSpeed);// her case de olmali
                bR.onClick.AddListener(DisableSelf);// her case de olmali 
               
                break;
            case 1:
                blText.text = "Two Barrel \n\n Movement Speed -1";
                brText.text = "XpGain +3 \n\n Movement Speed -1";
                bL.onClick.AddListener(() => BarrelSet(PlayerController.BarrelCount.two));
                bL.onClick.AddListener(() => SpeedSet(-1f));
                bL.onClick.AddListener(setGameSpeed);// her case de olmali
                bL.onClick.AddListener(DisableSelf);// her case de olmali 

                bR.onClick.AddListener(() => setXpGain(3));
                bR.onClick.AddListener(() => SpeedSet(-1f));
                bR.onClick.AddListener(setGameSpeed);// her case de olmali
                bR.onClick.AddListener(DisableSelf);// her case de olmali 
                break;
            case 2:
                blText.text = "Movement Speed +1 \n\n Fire Rate +0.3";
                brText.text = "Health +3 \n\n XpGain -2";
                bL.onClick.AddListener(() => SpeedSet(1f));
                bL.onClick.AddListener(() => fireRate(0.3f));
                bL.onClick.AddListener(setGameSpeed);// her case de olmali
                bL.onClick.AddListener(DisableSelf);// her case de olmali 

                bR.onClick.AddListener(() => setHealth(3));
                bR.onClick.AddListener(() => setXpGain(-2));
                bR.onClick.AddListener(setGameSpeed);// her case de olmali
                bR.onClick.AddListener(DisableSelf);// her case de olmali 
                break;
            case 3:
                blText.text = "Three Barrel \n\n XpGain -2";
                brText.text = "Fire Rate -0.3 \n\n One Barrel";
                bL.onClick.AddListener(() => BarrelSet(PlayerController.BarrelCount.three));
                bL.onClick.AddListener(() => setXpGain(-2));
                bL.onClick.AddListener(setGameSpeed);// her case de olmali
                bL.onClick.AddListener(DisableSelf);// her case de olmali 

                bR.onClick.AddListener(() => fireRate(-0.3f));
                bR.onClick.AddListener(() => BarrelSet(PlayerController.BarrelCount.one));
                bR.onClick.AddListener(setGameSpeed);// her case de olmali
                bR.onClick.AddListener(DisableSelf);// her case de olmali 
                break;
            case 4:
                blText.text = "XpGain +2 \n\n Movement Speed -1";
                brText.text = "Dmg +3 \n\n Fire Rate +0.3";
                bL.onClick.AddListener(() => setXpGain(2));
                bL.onClick.AddListener(() => SpeedSet(-1f));
                bL.onClick.AddListener(setGameSpeed);// her case de olmali
                bL.onClick.AddListener(DisableSelf);// her case de olmali

                bR.onClick.AddListener(() => SetDmg(3));
                bR.onClick.AddListener(() => fireRate(0.3f));
                bR.onClick.AddListener(setGameSpeed);// her case de olmali
                bR.onClick.AddListener(DisableSelf);// her case de olmali 
                break;
            case 5:
                blText.text = "Health +3 \n\n Movement Speed -1";
                brText.text = "Two Barrel \n\n Fire Rate +0.3";
                bL.onClick.AddListener(() => setHealth(3));
                bL.onClick.AddListener(() => SpeedSet(-1f));
                bL.onClick.AddListener(setGameSpeed);// her case de olmali
                bL.onClick.AddListener(DisableSelf);// her case de olmali 

                bR.onClick.AddListener(() => BarrelSet(PlayerController.BarrelCount.two));
                bR.onClick.AddListener(() => fireRate(0.3f));
                bR.onClick.AddListener(setGameSpeed);// her case de olmali
                bR.onClick.AddListener(DisableSelf);// her case de olmali 
                break;
            case 6:
                blText.text = "Dmg +3 \n\n XpGain -2";
                brText.text = "Three Barrel \n\n Health -3";
                bL.onClick.AddListener(() => SetDmg(3));
                bL.onClick.AddListener(() => setXpGain(-2));
                bL.onClick.AddListener(setGameSpeed);// her case de olmali
                bL.onClick.AddListener(DisableSelf);// her case de olmali 

                bR.onClick.AddListener(() => BarrelSet(PlayerController.BarrelCount.three));
                bR.onClick.AddListener(() => setHealth(-3));
                bR.onClick.AddListener(setGameSpeed);// her case de olmali
                bR.onClick.AddListener(DisableSelf);// her case de olmali 
                break;
            case 7:
                blText.text = "Fire Rate -0.3 \n\n XpGain -2";
                brText.text = "Health +3 \n\n One Barrel";
                bL.onClick.AddListener(() => fireRate(-0.3f));
                bL.onClick.AddListener(() => setXpGain(-2));
                bL.onClick.AddListener(setGameSpeed);// her case de olmali
                bL.onClick.AddListener(DisableSelf);// her case de olmali 

                bR.onClick.AddListener(() => setHealth(3));
                bR.onClick.AddListener(() => BarrelSet(PlayerController.BarrelCount.one));
                bR.onClick.AddListener(setGameSpeed);// her case de olmali
                bR.onClick.AddListener(DisableSelf);// her case de olmali 
                break;
            case 8:
                blText.text = "Fire Rate -0.3 \n\n Dmg - 3";
                brText.text = "Two Barrel \n\n XpGain -2";
                bL.onClick.AddListener(() => fireRate(-0.3f));
                bL.onClick.AddListener(() => SetDmg(-3));
                bL.onClick.AddListener(setGameSpeed);// her case de olmali
                bL.onClick.AddListener(DisableSelf);// her case de olmali 

                bR.onClick.AddListener(() => BarrelSet(PlayerController.BarrelCount.two));
                bR.onClick.AddListener(() => setXpGain(-2));
                bR.onClick.AddListener(setGameSpeed);// her case de olmali
                bR.onClick.AddListener(DisableSelf);// her case de olmali 
                break;


            default:
                break;
        }
    }

    public void fireRate(float fireRate)
    {

        if (fireRate < 0)
        {
            if (PlayerController.Instance.fireRate < Mathf.Abs(fireRate))
            {
                return;
            }
        }
        PlayerController.Instance.fireRate += fireRate;
        Debug.Log("b");

    }

    public void SpeedSet(float moveSpeed)
    {
        if (PlayerController.Instance.moveSpeed <= Mathf.Abs(moveSpeed))
        {
            return;
        }
        PlayerController.Instance.moveSpeed += moveSpeed;
        Debug.Log("c");

    }

    public void BarrelSet(PlayerController.BarrelCount barrel)
    {
        PlayerController.Instance.barrelCount = barrel;
    }

    public void setHealth(int health)
    {
        if (health < 0)
        {
            if (playerHealth.currentHealth < Mathf.Abs(health))
            {
                return;
            }
        }
        playerHealth.currentHealth += health;
        Debug.Log("d");


        if (playerHealth.currentHealth > playerHealth.maxHealth)
        {
            playerHealth.maxHealth = playerHealth.currentHealth;
            PlayerController.Instance.sliderMax();
        }
    }

    public void setXpGain(float xpGain)
    {
        if (xpGain < 0)
        {
            if (PlayerController.Instance.xpGain < Mathf.Abs(xpGain))
            {
                return;
            }
        }
        PlayerController.Instance.xpGain += xpGain;
    }
    public void setGameSpeed()
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
            if (objectPool.SharedInstance.pooledObjects[0].GetComponent<Damage>().damage < Mathf.Abs(dmg))
            {
                return;
            }
        }
        foreach (var item in objectPool.SharedInstance.pooledObjects)
        {
            item.GetComponent<Damage>().damage += dmg;
            Debug.Log("e");

        }
    }

    //public void setBulletSize(float size)
    //{
    //    foreach (var item in objectPool.SharedInstance.pooledObjects)
    //    {
    //        item.transform.localScale = new Vector3(size, size, size);
    //    }
    //}
}
