using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowLevelPlatforming : MonoBehaviour
{
    public Transform defaultSpawn;
    public Transform checkpoint1;
    public Transform checkpoint2;
    public Transform checkpoint3;
    public Transform checkpoint4;

    public static int checkPointNum;

    public GameObject player;

    void Start() {
        checkPointNum = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");

        if (other.gameObject.tag == "Player")
        {
            moveToCheckpoint();
        }
    }

    public void moveToCheckpoint() {
        switch (checkPointNum) {
            case 1:
                player.SetActive(false);
                player.transform.position = defaultSpawn.position;
                player.gameObject.SetActive(true);
                break;
            case 2:
                player.SetActive(false);
                player.transform.position = checkpoint1.position;
                player.gameObject.SetActive(true);
                break;
            case 3:
                player.SetActive(false);
                player.transform.position = checkpoint2.position;
                player.gameObject.SetActive(true);
                break;
            case 4:
                player.SetActive(false);
                player.transform.position = checkpoint3.position;
                player.gameObject.SetActive(true);
                break;
            case 5:
                player.SetActive(false);
                player.transform.position = checkpoint4.position;
                player.gameObject.SetActive(true);
                break;
        }
    }
}
