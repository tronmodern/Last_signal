using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartNewGame()
    {
        // Метод для загрузки сцены новой игры
        SceneManager.LoadScene("SampleScene");
    }

    public void OpenSettings()
    {
        // Метод для загрузки сцены настроек
        SceneManager.LoadScene("Settings");
    }

    public void ExitGame()
    {
        // Метод для выхода из игры
        Application.Quit();
    }
}