using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForce : MonoBehaviour
{

    Rigidbody2D smallgun, maingun, tankhead;
    [SerializeField]
    [Range(1, 100f)]
    float speed = 10;
    [SerializeField]
    [Range(1, 2000f)]
    float modifier= 10;
    
    public GameObject abullet, rbullet;

    bool canShoot = true;
    

    // Start is called before the first frame update
    void Start()
    {
        //Head = GameObject.Find("Head").GetComponent<Rigidbody2D>();
        //smallgun = GameObject.Find("smallgun").GetComponent<Rigidbody2D>();
        //tankhead = GameObject.Find("tankbase").GetComponent<Rigidbody2D>();

        maingun = GameObject.Find("maingun").GetComponent<Rigidbody2D>();
        //Hand = GameObject.Find("Hand").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerControls();
    }

    private void playerControls()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            maingun.AddRelativeForce(Vector2.right * speed * modifier * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            maingun.AddRelativeForce(Vector2.left * speed * modifier * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            shoot(rbullet);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            shoot(abullet);
        }
    }

    private void shoot(GameObject bulletType)
    {
        if (canShoot)
        {
            Instantiate(bulletType, GameObject.Find("gunbarrel").gameObject.transform);
            canShoot = false;
            StartCoroutine(shootTimer());
        }
    }
    IEnumerator shootTimer() {
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }
}
