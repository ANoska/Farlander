using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MountainLevelManager : MonoBehaviour
{
    // Player members
    public GameObject player;
    public Transform spawnPoint;

    // UI
    public Text outOfBoundsText;
    public Text timerText;

    // Timer info
    public float startTime;
    public float timeLimit;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        float timeRemaining = timeLimit - (Time.time - startTime);
        timerText.text = string.Format("Time Remaining:\n{0}", TimeSpan.FromSeconds(timeRemaining).ToString(@"mm\:ss"));
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
