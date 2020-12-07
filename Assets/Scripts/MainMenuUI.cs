using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public Button playButton;

    private const string FIRST_LEVEL_NAME = "ForestLevel";

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(() => SceneManager.LoadScene(FIRST_LEVEL_NAME));
    }
}
