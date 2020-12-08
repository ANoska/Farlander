using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointRotation : MonoBehaviour {
    public GameObject checkpoint;

    private void Start() {
        checkpoint = this.gameObject;
    }
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
