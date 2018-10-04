using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMovingTargets : MonoBehaviour
{

    float timer = 0;
    public GameObject newObject;


    void Start()
    {

    }

    void Update()
    {

        timer += Time.deltaTime;
        float xrange = Random.Range(4, 22);
        float yrange = Random.Range(-10, 10);

        if (timer >= 1 && GSDManager.Instance.enemies < GSDManager.Instance.maxenemies)
        {
            Vector3 newPosition = new Vector3(GameObject.Find("gsdefender").transform.position.x + xrange, transform.position.y + yrange, 0);
            GameObject t = (GameObject)(Instantiate(newObject, newPosition, Quaternion.identity));
            timer = 0;
            GSDManager.Instance.enemies++;
        }

    }
}
