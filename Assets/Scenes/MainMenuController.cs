using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartNewGame()
    {
        // ����� ��� �������� ����� ����� ����
        SceneManager.LoadScene("SampleScene");
    }

    public void OpenSettings()
    {
        // ����� ��� �������� ����� ��������
        SceneManager.LoadScene("Settings");
    }

    public void ExitGame()
    {
        // ����� ��� ������ �� ����
        Application.Quit();
    }
}