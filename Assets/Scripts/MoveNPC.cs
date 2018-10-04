using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNPC : MonoBehaviour
{

    public GameObject zbullet, explosion;
    public float direction = 2.0f;
    public float timer;

    void Start()
    {

    }

    void Update()
    {

        // add code to randomly generate timer values for changing directions
        // add code to restrict enemies to the screen

        //float xrange = Random.Range(4, 6);
        //float yrange = Random.Range(4, 6);
        float shootrand = Random.Range(1, 600);
        float moverand = Random.Range(1, 20);

        timer += Time.deltaTime;

        if (moverand == 4) transform.Translate(Vector3.down * direction * Time.deltaTime * 2);
        else if (moverand == 5) transform.Translate(Vector3.up * direction * Time.deltaTime * 2);
        else transform.Translate(Vector3.up * direction * Time.deltaTime * 2);

        if (timer >= 2)
        {
            direction = -direction;
            timer = 0;
        }
        if (shootrand == 3)
        {
            shootrand = 0;
            Shoot();
        }

        Vector3 viewPortPosition = Camera.main.WorldToViewportPoint(transform.position);
        Vector3 viewPortXDelta = Camera.main.WorldToViewportPoint(transform.position + Vector3.left / 2);
        Vector3 viewPortYDelta = Camera.main.WorldToViewportPoint(transform.position + Vector3.up / 2);

        float deltaX = viewPortPosition.x - viewPortXDelta.x;
        float deltaY = viewPortPosition.y - viewPortXDelta.y;

        viewPortPosition.x = Mathf.Clamp(viewPortPosition.x, 0 + deltaX, 1 - deltaX);
        viewPortPosition.y = Mathf.Clamp(viewPortPosition.y, 0 + deltaY, 1 - deltaY);
        transform.position = Camera.main.ViewportToWorldPoint(viewPortPosition);
    }

    void Shoot()
    {
        GSDManager.Instance.source.PlayOneShot(GSDManager.Instance.alienFire, 1);
        GameObject b = (GameObject)(Instantiate(zbullet, transform.position, Quaternion.identity));
        b.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 200);
    }

}
