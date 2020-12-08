using UnityEngine;

public class SpeedPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<ThirdPersonMovement>().OnSpeedBoostPickup();
            this.gameObject.SetActive(false);
        }
    }
}
