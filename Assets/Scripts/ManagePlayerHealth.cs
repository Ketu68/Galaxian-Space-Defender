using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagePlayerHealth : MonoBehaviour
{

    public int score;
    public GameObject explosion, laser, newObject, t;

    void Start()
    {
        score = 0;

        GameObject.Find("scoreUI").GetComponent<Text>().text = "SCORE : ";

    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "bullet")
        {
            GSDManager.Instance.source.PlayOneShot(GSDManager.Instance.playerHitSound, 1);
            StartOver();
        }
    }

    public void IncreaseScore()
    {
        score += 100;
        GameObject.Find("scoreUI").GetComponent<Text>().text = "SCORE : " + score;
    }

    public IEnumerator FreezeFor()
    {
         yield return new WaitForSeconds(4);
         StartOver();

            // Insert Game Over screen here.  Using main menu to test for now

         GameObject exp1 = (GameObject)(Instantiate(explosion, transform.position, Quaternion.identity));
         Destroy(exp1, 3f);

    }

    public void StartOver() {

        Destroy(transform.gameObject);

        GSDManager.Instance.source.Stop();
        GSDManager.Instance.soundtrack.Stop();
        GSDManager.Instance.EndTheScene();

    }
}
