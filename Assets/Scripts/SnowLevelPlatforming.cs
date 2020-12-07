using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowLevelPlatforming : MonoBehaviour
{
    public GameObject checkpoint1;
    public GameObject player;

    //this is attatched to the fail zone
    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player") {
            Debug.Log("contact");
            player.SetActive(false);
            player.transform.position = checkpoint1.transform.position;
            player.gameObject.SetActive(true);
        }
    }

    //this is what Nathan used in his RedCoin Script:
    /*
    void OnControllerColliderHit(ControllerColliderHit coll) {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "failzone") {
            Debug.Log("contact");
            player.SetActive(false);
            player.transform.position = checkpoint1.transform.position;
            player.gameObject.SetActive(true);
        }
    }
    */
}
