using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public Button resumeButton;
    public Button mainMenuButton;

    private bool isPaused = false;
    private ThirdPersonCamera thirdPersonCamera;

    void Start()
    {
        if (pauseMenuUI == null)
        {
            Debug.LogError("PauseMenuUI is not assigned!");
        }
        if (resumeButton == null)
        {
            Debug.LogError("ResumeButton is not assigned!");
        }
        if (mainMenuButton == null)
        {
            Debug.LogError("MainMenuButton is not assigned!");
        }

        // �������� �� ������� ������
        resumeButton.onClick.AddListener(Resume);
        mainMenuButton.onClick.AddListener(LoadMainMenu);

        // ��������� ������ �� ������
        thirdPersonCamera = Camera.main.GetComponent<ThirdPersonCamera>();
        if (thirdPersonCamera == null)
        {
            Debug.LogError("ThirdPersonCamera not found on the Main Camera!");
        }

        Resume(); // ����������, ��� ���� �� �� ����� ��� ������
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        thirdPersonCamera.LockCursor();
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        thirdPersonCamera.UnlockCursor();
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // ���������� ���������� �����
        SceneManager.LoadScene("MainMenu"); // �������� "MainMenu" �� �������� ����� ����� �������� ����
    }
}