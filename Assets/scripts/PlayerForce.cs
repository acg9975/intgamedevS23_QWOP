using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForce : MonoBehaviour
{

    Rigidbody2D Head, Torso, maingun, Hand;
    SliderJoint2D ArmSlider;
    [SerializeField]
    [Range(1, 100f)]
    float speed = 10;
    [SerializeField]
    [Range(1, 2000f)]
    float modifier= 10;
    GameObject bullet;

    bool canShoot = true;
    

    // Start is called before the first frame update
    void Start()
    {
        //Head = GameObject.Find("Head").GetComponent<Rigidbody2D>();
        Torso = gameObject.GetComponent<Rigidbody2D>();
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
        }

    }

    private void shoot()
    {
        if (canShoot)
        {
            //Instantiate(bullet,)
            StartCoroutine(shootTimer());
        }
    }
    IEnumerator shootTimer() {
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }
}
