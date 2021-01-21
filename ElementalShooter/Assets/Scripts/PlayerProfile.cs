using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfile : MonoBehaviour
{
    //TODO Rename this class, it's not a playerprofile
    [SerializeField] GameObject spaceShip;
    [SerializeField] SpriteRenderer spacehshipSprite;//TODO delete this, is just for prototype
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] Camera cam;
    [SerializeField] float waitForFireTime;
    [SerializeField] float fireTimer;
    ElementalWeapon currentElement;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (InputController.IsButtonPressed())
        {
            Vector3 v = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

            spaceShip.transform.position = new Vector3(v.x, spaceShip.transform.position.y, spaceShip.transform.position.z);
            Debug.Log(v.ToString());
            if (fireTimer >= waitForFireTime)
            {
                GameObject g=Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
                Bullet b = g.GetComponent<Bullet>();

                switch (currentElement)
                {
                    case ElementalWeapon.Fire:
                        b.bulletSprite.color = Color.red;
                        break;
                    case ElementalWeapon.Air:
                        b.bulletSprite.color = Color.white;
                        break;
                    case ElementalWeapon.Water:
                        b.bulletSprite.color = Color.cyan;
                        break;
                    case ElementalWeapon.Earth:
                        b.bulletSprite.color = Color.black;
                        break;
                    default:
                        Debug.LogError("U fucked up the element");
                        break;
                }
                fireTimer = 0;
            }
            else
            {
                fireTimer += Time.deltaTime;
            }
        }
    }

    public void SetElementalWeapon(int element)
    {
        currentElement = (ElementalWeapon)element;
        switch ((ElementalWeapon)element)
        {
            case ElementalWeapon.Fire:
                spacehshipSprite.color = Color.red;
               break;
            case ElementalWeapon.Air:
                spacehshipSprite.color = Color.white;
                break;
            case ElementalWeapon.Water:
                spacehshipSprite.color = Color.cyan;
                break;
            case ElementalWeapon.Earth:
                spacehshipSprite.color = Color.black;
                break;
            default:
                Debug.LogError("U fucked up the element");
                break;
        }
    }
}

public enum ElementalWeapon { Fire=0,Air=1,Water=2,Earth=3}