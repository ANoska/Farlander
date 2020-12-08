using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
    private GameObject platform;
    public float rotationSpeed = 5f;
    // Start is called before the first frame update
    void Start() {
        platform = this.gameObject;
    }

    // Update is called once per frame
    void Update() {
        platform.transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
    }
}
