using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class LevelChange : MonoBehaviour
{

    Scene gameScene;
    string Level;
    // Start is called before the first frame update
    void Start()
    {
        gameScene = SceneManager.GetActiveScene();
        Level = gameScene.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnControllerColliderHit(ControllerColliderHit coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Portal")
        {
            if(Level == "ForestLevel")
            {
                SceneManager.LoadScene("DesertLevel");
            }
            else if(Level == "DesertLevel")
            {
                SceneManager.LoadScene("MountainLevel");
            }
            else if(Level == "MountainLevel")
            {
                SceneManager.LoadScene("SnowLevel");
            }
            else if(Level == "SnowLevel")
            {

            }
          
        }
    }
}
