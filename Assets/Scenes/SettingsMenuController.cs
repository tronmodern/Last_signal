using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenuController : MonoBehaviour
{
    public Slider Slider;
    public Button BackToMainMenuButton;

    void Start()
    {
        // �������� ������������ �������� ���������
        Slider.value = PlayerPrefs.GetFloat("Volume", 1f);

        // ���������� ��������� ��� ��������� �������� ��������
        Slider.onValueChanged.AddListener(SetVolume);

        // ��������� ������ ��� �������� � ������� ����
        BackToMainMenuButton.onClick.AddListener(BackToMainMenu);
    }

    public void SetVolume(float volume)
    {
        // ��������� ��������� ����� MusicManager � ���������� ��������
        if (MusicManager.Instance != null)
        {
            MusicManager.Instance.SetVolume(volume);
        }
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }

    public void BackToMainMenu()
    {
        // ������� � ������� ����
        SceneManager.LoadScene("MainMenu");
    }
}