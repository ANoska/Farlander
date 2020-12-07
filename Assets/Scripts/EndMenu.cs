using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    public Button mainMenuButton;

    private const string MAIN_MENU_NAME = "_MainMenu";

    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        mainMenuButton.onClick.AddListener(() => SceneManager.LoadScene(MAIN_MENU_NAME));
    }
}
