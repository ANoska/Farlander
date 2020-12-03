using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{

    
        public GameObject slab;
        public float speed;

        public void Update()
        {
            float y = Mathf.PingPong(Time.time * speed, 2) * 6 - 3 - 83;
            slab.transform.position = new Vector3((float)-1.14, y, (float)187.37);
        }
    
}
