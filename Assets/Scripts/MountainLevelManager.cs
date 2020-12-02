using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MountainLevelManager : MonoBehaviour
{
    public GameObject player;
    private CharacterController playerController;

    public Transform spawnPoint;

    public Text outOfBoundsText;

    void Awake()
    {
        if (player != null)
            playerController = player.GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnPlayerOutOfBounds()
    {
        player.SetActive(false);
        player.transform.position = spawnPoint.transform.position;
        player.SetActive(true);

        if (!outOfBoundsText.gameObject.activeSelf)
            StartCoroutine(UiOnPlayerOutOfBounds());
    }

    private IEnumerator UiOnPlayerOutOfBounds()
    {
        outOfBoundsText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        outOfBoundsText.gameObject.SetActive(false);
    }
}
