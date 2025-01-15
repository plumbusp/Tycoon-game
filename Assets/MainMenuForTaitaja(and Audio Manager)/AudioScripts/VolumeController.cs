using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class VolumeController: MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _SFXSlider;

    const string MIXER_MASTER = "MasterVolume";    // Exposed param of Master volume (in AudioMixer)
    const string MIXER_MUSIC = "MusicVolume";    // Exposed param of Music volume (in AudioMixer)
    const string MIXER_SFX = "SFXVolume";        // Exposed param of SFX volume (in AudioMixer)

    private void Awake()
    {
        try
        {
            _masterVolumeSlider.onValueChanged.AddListener(ChangeMasterVolume);
            _musicSlider.onValueChanged.AddListener(ChangeMusicVolume);
            _SFXSlider.onValueChanged.AddListener(ChangeSFXVolume);
        }
        catch(System.Exception e)
        {
            Debug.LogWarning("Check if you assiged sliders!!!    " + e);
        }
    }
    private void OnDestroy()
    {
        _musicSlider.onValueChanged.RemoveListener(ChangeMusicVolume);
        _SFXSlider.onValueChanged.RemoveListener(ChangeSFXVolume);
    }
    private void ChangeMasterVolume(float value)
    {
        _audioMixer.SetFloat(MIXER_MASTER, Mathf.Log10(value) * 20f);
    }
    private void ChangeMusicVolume(float value)
    {
        _audioMixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20f);
    }
    private void ChangeSFXVolume(float value)
    {
        _audioMixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20f);
    }

}
