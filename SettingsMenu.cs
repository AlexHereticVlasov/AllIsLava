using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    [Header("AudioMixers")]
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioMixer _musicMixer;

    [Header("UI Elements")]
    [SerializeField] private Dropdown _qualityDropdown;
    [SerializeField] private Dropdown _resolutionDropdown;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private Slider _musicSlider;

    private Resolution[] res;

    void Start()
    {
        AddQuality();
        AddResolutions();
        SetDefoultVolume("Volume", _volumeSlider, _audioMixer);
        SetDefoultVolume("Music", _musicSlider, _musicMixer);
    }

    private void AddQuality()
    {
        _qualityDropdown.ClearOptions();
        _qualityDropdown.AddOptions(QualitySettings.names.ToList());
        if (PlayerPrefs.HasKey("Quality"))
        {
            _qualityDropdown.value = PlayerPrefs.GetInt("Quality");
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"));
        }
        else
        {
            _qualityDropdown.value = QualitySettings.GetQualityLevel();
        }
    }

    private void AddResolutions()
    {
        _resolutionDropdown.ClearOptions();
        Resolution[] resolutions = Screen.resolutions;
        res = resolutions.Distinct().ToArray();
        string[] strRes = new string[res.Length];
        for (int i = 0; i < res.Length; i++)
        {
            strRes[i] = res[i].width + "x" + res[i].height;
        }
        _resolutionDropdown.AddOptions(strRes.ToList());
        if (PlayerPrefs.HasKey("Resolution"))
        {
            _resolutionDropdown.value = PlayerPrefs.GetInt("Resolution");
            Screen.SetResolution(res[_resolutionDropdown.value].width,
                res[_resolutionDropdown.value].height,
                Screen.fullScreen);
        }
        else
        {
            Screen.SetResolution(res[res.Length - 1].width, res[res.Length - 1].height, Screen.fullScreen);
        }
    }

    public void SetQuality()
    {
        QualitySettings.SetQualityLevel(_qualityDropdown.value);
        PlayerPrefs.SetInt("Quality", _qualityDropdown.value);
    }

    public void SetRes()
    {
        Screen.SetResolution(res[_resolutionDropdown.value].width, res[_resolutionDropdown.value].height, Screen.fullScreen);
        PlayerPrefs.SetInt("Resolution", _resolutionDropdown.value);
    }

    public void SetVolume(float volume)
    {
        _audioMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("Volume", volume);
    }

    public void SetMusic(float volume)
    {
        _musicMixer.SetFloat("Music", volume);
        PlayerPrefs.SetFloat("Music", volume);
    }

    private void SetDefoultVolume(string key, Slider slider, AudioMixer audioMixer)
    {
        if (PlayerPrefs.HasKey(key))
        {
            slider.value = PlayerPrefs.GetFloat(key);
            audioMixer.SetFloat(key, PlayerPrefs.GetFloat(key));
        }
        else
        {
            audioMixer.SetFloat(key, slider.value);
        }
    }
}

