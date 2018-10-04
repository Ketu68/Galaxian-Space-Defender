using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public GameObject explosion, laser;

    void Start()
    {
        Destroy(gameObject, 4);
    }

    void Update() { }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            if (GSDManager.Instance.enemies > 0) GSDManager.Instance.enemies--;

            GSDManager.Instance.IncreaseScore();
            GSDManager.Instance.source.PlayOneShot(GSDManager.Instance.alienHitSound, 1);

            GameObject exp = (GameObject)(Instantiate(explosion, transform.position, Quaternion.identity));
            Destroy(exp, .5f);
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
    }
}


