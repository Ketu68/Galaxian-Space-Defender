using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagePlayerHealth : MonoBehaviour
{

    void Start()
    {
        GSDManager.Instance.score = 0;

        GameObject.Find("scoreUI").GetComponent<Text>().text = "SCORE : ";

    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "bullet")
        {
            //GSDManager.Instance.source.PlayOneShot(GSDManager.Instance.playerHitSound, 1);
            //if (!GSDManager.Instance.source.isPlaying) GSDManager.Instance.StartOver();
            //else
            //{
            //    GSDManager.Instance.FreezeFor();
            //    GSDManager.Instance.StartOver();
            //}
        }
    }


}
