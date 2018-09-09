using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmitter : MonoBehaviour {
    ObjectPooler bulletPool;
    bool fireEnabled = false;
    [SerializeField] float shotCounter;
    [SerializeField] float timeBetweenBullets;

	// Use this for initialization
	void Start () {
        bulletPool = ObjectPooler.instance;
        timeBetweenBullets = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
        if (fireEnabled)
        {
            CountdownAndFire();
        }
    }

    private void CountdownAndFire()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = timeBetweenBullets;
        }
    }

    private void Fire()
    {
        GameObject nextInactiveBullet = bulletPool.GetPooledObject("Bullet");

        if (!nextInactiveBullet) return;

        nextInactiveBullet.transform.position = transform.position;
        nextInactiveBullet.transform.rotation = transform.rotation;
        nextInactiveBullet.SetActive(true);
    }

    public void ToggleFireEnabled()
    {
        fireEnabled = !fireEnabled;
    }
}
