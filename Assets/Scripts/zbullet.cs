using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zbullet : MonoBehaviour
{

    public GameObject explosion;

    void Start()
    {
        Destroy(gameObject, 6);
    }

    void Update() { }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject exp = (GameObject)(Instantiate(explosion, transform.position, Quaternion.identity));
            Destroy(exp, .5f);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
