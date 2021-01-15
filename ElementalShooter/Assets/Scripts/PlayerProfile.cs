using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfile : MonoBehaviour
{
    [SerializeField] GameObject spaceShip;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] Camera cam;
    [SerializeField] float waitForFireTime;
    [SerializeField] float fireTimer;
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
                Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
                fireTimer = 0;
            }
            else
            {
                fireTimer += Time.deltaTime;
            }
        }
    }
}
