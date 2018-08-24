using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField] float speed = 10f;
    [SerializeField] float deletionTime = 2f;

    private void OnEnable()
    {
        Invoke("Destroy", deletionTime);
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(0, speed * Time.deltaTime, 0);
	}

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
