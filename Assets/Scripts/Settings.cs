using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Toggle vSyncToggle;
    public Slider maxFPSSlider;
    public TMP_Text maxFPSText;
    public Dropdown resolutionDropdown;
    public FullScreenMode fullScreenMode = FullScreenMode.FullScreenWindow;

    private void Awake()
    {
        vSyncToggle.onValueChanged.AddListener(ToggleVSync);
        maxFPSSlider.onValueChanged.AddListener(SetMaxFPS);
        resolutionDropdown.onValueChanged.AddListener(SetResolution);

        resolutionDropdown.ClearOptions();

        // Get the list of available resolutions
        Resolution[] resolutions = Screen.resolutions;
        int maxResolutions = Mathf.Min(resolutions.Length, 20);

        for (int i = 0; i < maxResolutions; i++)
        {
            Resolution resolution = resolutions[i];
            Dropdown.OptionData option = new Dropdown.OptionData(
                string.Format("{0}x{1}", resolution.width, resolution.height)
            );
            resolutionDropdown.options.Add(option);
        }

        // Set the default selection to the native resolution
        Resolution nativeResolution = Screen.currentResolution;
        int selectedIndex = 0;
        for (int i = 0; i < maxResolutions; i++)
        {
            if (
                resolutions[i].width == nativeResolution.width
                && resolutions[i].height == nativeResolution.height
            )
            {
                selectedIndex = i;
                break;
            }
        }
        resolutionDropdown.value = selectedIndex;
        resolutionDropdown.RefreshShownValue();

        // Set the target frame rate
        Application.targetFrameRate = (int)maxFPSSlider.value;

        // Display the value of the slider
        maxFPSText.text = "FPS Limiter - " + maxFPSSlider.value.ToString();
    }

    private void ToggleVSync(bool isOn)
    {
        QualitySettings.vSyncCount = isOn ? 1 : 0;
    }

    private void SetMaxFPS(float value)
    {
        Application.targetFrameRate = (int)value;

        // Update the text to display the value of the slider
        maxFPSText.text = "FPS Limiter - " + value.ToString();
    }

    private void SetResolution(int index)
    {
        Resolution[] resolutions = Screen.resolutions;

        // Set the resolution
        Screen.SetResolution(resolutions[index].width, resolutions[index].height, fullScreenMode);
    }
}
