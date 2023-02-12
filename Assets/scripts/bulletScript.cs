using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{

    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.transform.Translate(Vector3.up * Time.deltaTime * 3);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
