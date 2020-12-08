using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public GameObject outOfTimeMenu;
    public Button tryAgainButton;
    public float startTime;
    public float timeLimit;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;

        tryAgainButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimerText();

        // Restart the level if the 'r' key is pressed
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void UpdateTimerText()
    {
        if (outOfTimeMenu.activeSelf)
            return;

        float timeRemaining = timeLimit - (Time.time - startTime);
        if (timeRemaining <= 0)
        {
            OutOfTime();
            return;
        }
        timerText.text = string.Format("Time Remaining:\n{0}", TimeSpan.FromSeconds(timeRemaining).ToString(@"mm\:ss"));
    }

    private void OutOfTime()
    {
        outOfTimeMenu.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        player.SetActive(false);
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
