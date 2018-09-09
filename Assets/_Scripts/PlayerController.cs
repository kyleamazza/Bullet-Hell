using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] int lives = 3;
    [SerializeField] int bombs = 2;
    [SerializeField] float movementSpeed = 8f;
    [SerializeField] float padding = 0.1f;

    float lastBulletTime;
    [SerializeField] float fireRate = 0.08f;

    [SerializeField] GameObject bullet;
    ObjectPooler bulletPool;
    List<GameObject> bullets;
    Vector3 bulletOffsetX = new Vector3(-0.15f, 0);

    float xMin, xMax, yMin, yMax;

    // Use this for initialization
    void Start () {
        InitializeMovementBoundaries();
        bulletPool = ObjectPooler.instance;
	}
	
	// Update is called once per frame
	void Update () {
        MovePlayer();
        Shoot();
        Bomb();
	}

    void MovePlayer()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            movementSpeed /= 2f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            movementSpeed *= 2f;
        }
        float deltaX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * movementSpeed;
        float deltaY = Input.GetAxisRaw("Vertical") * Time.deltaTime * movementSpeed;

        float newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        float newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newXPos, newYPos);
    }

    private void Shoot()
    {
        if (Input.GetKey(KeyCode.Z) && hasClearedBulletDelayTimer())
        {
            lastBulletTime = Time.time;
            ActivateBullet();
            SoundManager.instance.PlayAudioParameter(AudioName.laserShot);
        }
    }

    private void ActivateBullet()
    {
        GameObject nextInactiveBullet = bulletPool.GetPooledObject("Bullet");

        if (!nextInactiveBullet) return;

        nextInactiveBullet.transform.position = transform.position + bulletOffsetX;
        nextInactiveBullet.transform.rotation = transform.rotation;
        nextInactiveBullet.SetActive(true);
    }

    private void Bomb()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Bomb");
            // bomb it up
        }
    }

    private void InitializeMovementBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(Vector3.zero).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(Vector3.right).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(Vector3.zero).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(Vector3.up).y - padding;
    }

    private bool hasClearedBulletDelayTimer()
    {
        return Time.time - lastBulletTime > fireRate;
    }
}
