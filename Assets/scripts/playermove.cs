using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    GameObject moversquare;
    // Start is called before the first frame update
    void Start()
    {
        moversquare = GameObject.Find("moversquare").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * 1 * Time.deltaTime);
        moversquare.transform.Translate(Vector3.up * 1 * Time.deltaTime);
    }
}
