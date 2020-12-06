using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowLevelPlatforming : MonoBehaviour
{
    public GameObject checkpoint1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            Debug.Log("contact");
            other.gameObject.SetActive(false);
            other.transform.position = checkpoint1.transform.position;
            other.gameObject.SetActive(true);
        }
    }
}
