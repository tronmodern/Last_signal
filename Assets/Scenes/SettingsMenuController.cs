using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenuController : MonoBehaviour
{
    public Slider Slider;
    public Button BackToMainMenuButton;

    void Start()
    {
        // Загрузка сохраненного значения громкости
        Slider.value = PlayerPrefs.GetFloat("Volume", 1f);

        // Добавление слушателя для изменения значения ползунка
        Slider.onValueChanged.AddListener(SetVolume);

        // Настройка кнопки для возврата в главное меню
        BackToMainMenuButton.onClick.AddListener(BackToMainMenu);
    }

    public void SetVolume(float volume)
    {
        // Установка громкости через MusicManager и сохранение значения
        if (MusicManager.Instance != null)
        {
            MusicManager.Instance.SetVolume(volume);
        }
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }

    public void BackToMainMenu()
    {
        // Возврат в главное меню
        SceneManager.LoadScene("MainMenu");
    }
}