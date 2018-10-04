using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{

    public GameObject laser, explosion, shipflip;
    public bool facingright = true;
    public string firedirection = "right";

    void Start()
    {

    }

    public void Update()
    {

        //        float horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Flip();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(!GSDManager.Instance.source.isPlaying) GSDManager.Instance.source.PlayOneShot(GSDManager.Instance.thrust, 1);
            gameObject.transform.Translate(Vector3.left * 0.2f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!GSDManager.Instance.source.isPlaying) GSDManager.Instance.source.PlayOneShot(GSDManager.Instance.thrust, 1);
            gameObject.transform.Translate(Vector3.right * 0.2f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
             gameObject.transform.Translate(Vector3.up * 0.2f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
             gameObject.transform.Translate(Vector3.down * 0.2f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GSDManager.Instance.source.PlayOneShot(GSDManager.Instance.fireSound, 1);

            if (facingright)
            {
                GameObject b = (GameObject)(Instantiate(laser, transform.position + transform.right * 2.7f, Quaternion.identity));
                b.GetComponent<Rigidbody2D>().AddForce(transform.right * 1800);
            }
            else
            {
                GameObject b = (GameObject)(Instantiate(laser, transform.position + transform.right * -2.7f, Quaternion.identity));
                b.GetComponent<Rigidbody2D>().AddForce(transform.right * -1800);
            }

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet" || collision.gameObject.tag == "enemy")
        {
            Debug.Log("Player was hit inside MovePlayer");
            for (int x = 0; x < 10; x++)
            {
                deadFlip();
                Vector3 viewPortPosition = Camera.main.WorldToViewportPoint(transform.position);
                Vector3 viewPortXDelta = Camera.main.WorldToViewportPoint(transform.position + Vector3.left / 2);
                Vector3 viewPortYDelta = Camera.main.WorldToViewportPoint(transform.position + Vector3.up / 2);

                float deltaX = viewPortPosition.x - viewPortXDelta.x;
                float deltaY = viewPortPosition.y - viewPortXDelta.y;

                viewPortPosition.x = Mathf.Clamp(viewPortPosition.x, 0 + deltaX, 1 - deltaX);
                viewPortPosition.y = Mathf.Clamp(viewPortPosition.y, 0 + deltaY, 1 - deltaY);
                transform.position = Camera.main.ViewportToWorldPoint(viewPortPosition);
            }
            Debug.Log("After the flip loop");

            GameObject exp = (GameObject)(Instantiate(explosion, transform.position, Quaternion.identity));
            Destroy(exp, 3f);
            Destroy(collision.gameObject);
            Destroy(gameObject);

            GSDManager.Instance.lives--;
            GSDManager.Instance.StartOver();

            //if (!GSDManager.Instance.source.isPlaying)
            //{
            //    GSDManager.Instance.StartOver();
            //}
            //else
            //{
            //    GSDManager.Instance.FreezeFor();
            //    GSDManager.Instance.StartOver();
            //}
        }
    }

    private void Flip()
    {
        facingright = !facingright;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        GameObject flip = (GameObject)(Instantiate(shipflip, transform.position, Quaternion.identity));
        Destroy(flip, .4f);
        //Destroy(gameObject);
        //return;
    }
    private void deadFlip()
    {
        facingright = !facingright;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        GameObject flip = (GameObject)(Instantiate(shipflip, transform.position, Quaternion.identity));
        Destroy(flip, 3f);
        //Destroy(gameObject);
        //return;
    }
}
