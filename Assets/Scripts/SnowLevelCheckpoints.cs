using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SnowLevelCheckpoints : MonoBehaviour
{
    public bool isReached = false;
    
    void OnTriggerEnter(Collider other) {
        Debug.Log("OnTriggerEnter");

        if (other.gameObject.tag == "Player" && isReached == false) {
            isReached = true;
            SnowLevelPlatforming.checkPointNum++;
            Debug.Log("Checkpoint Reached!");
        }
    }
}
