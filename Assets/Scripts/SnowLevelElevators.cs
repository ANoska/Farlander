using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowLevelElevators : MonoBehaviour {

    private GameObject platform;

    public float maxHeight = 10f;
    public float minHeight = -10f;
    public float speed = 10f;

    public bool up = true;

    // Start is called before the first frame update
    void Start() {
        platform = this.gameObject;
    }

    // Update is called once per frame
    void Update() {
        if (up == true) {
            platform.transform.Translate(Vector3.up * speed * Time.deltaTime, Space.Self);
            if (platform.transform.localPosition.y > maxHeight) {
                up = false;
            }
        } else {
            platform.transform.Translate(-Vector3.up * speed * Time.deltaTime, Space.Self);
            if (platform.transform.localPosition.y < minHeight) {
                up = true;
            }
        }
    }
}