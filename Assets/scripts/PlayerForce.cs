using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerForce : MonoBehaviour
{

    Rigidbody2D tankbase, maingun, moversquare;
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
        tankbase = GameObject.Find("tankbase").GetComponent<Rigidbody2D>();
        maingun = GameObject.Find("maingun").GetComponent<Rigidbody2D>();
        moversquare = GameObject.Find("moversquare").GetComponent<Rigidbody2D>();
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
            moversquare.AddRelativeForce(Vector2.right * speed * modifier * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            moversquare.AddRelativeForce(Vector2.left * speed * modifier * Time.deltaTime);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot(rbullet);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("boundary"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
