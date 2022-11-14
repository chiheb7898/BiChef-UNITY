using UnityEngine ;
using UnityEngine.UI ;

public class SettingsUI : MonoBehaviour {
    [Header("UI References :")]
    [SerializeField] private GameObject uiCanvas;
    [SerializeField] private Button uiCloseButton;
    [SerializeField] private Button uilogoutButton;
    [Space]
    [SerializeField] private Toggle uiVibrationToggle;
    [SerializeField] private Slider uiMusicSlider;
    [SerializeField] private Slider uiSoundsSlider;

    [SerializeField] private Text uiplayer;


    private void Awake() {
        //Add Listeners:
        uiCloseButton.onClick.AddListener(Close);

        //Settings closed by default:
        Close();

        //Update UI with saved values in player prefs:--------------------------------------
        uiVibrationToggle.isOn = Settings.VibrationEnabled;
        uiMusicSlider.value = Settings.MusicVolume;
        uiSoundsSlider.value = Settings.SoundsVolume;
        //  uiLanguagesDropDown.value = Settings.SelectedLanguage ;
        //  uiPlayerNameInputField.text = Settings.PlayerName ;

        // Add UI elements listeners :------------------------------------------------------
        uiVibrationToggle.onValueChanged.AddListener(OnVibrationToggleChange);
        uiMusicSlider.onValueChanged.AddListener(OnMusicSliderChange);
        uiSoundsSlider.onValueChanged.AddListener(OnSoundsSliderChange);
        // uiLanguagesDropDown.onValueChanged.AddListener (OnLanguagesDropDownChange) ;
        //  uiPlayerNameInputField.onValueChanged.AddListener (OnPlayerNameInputFieldChange) ;
    }


    // UI Events: -------------------------------------------------------------------------
    private void OnVibrationToggleChange(bool value) {
        Settings.VibrationEnabled = value;
    }

    private void OnMusicSliderChange(float value) {
        Settings.MusicVolume = value;
    }

    private void OnSoundsSliderChange(float value) {
        Settings.SoundsVolume = value;
    }





    // -------------------------------------------------------------------------------------
    public void Open() {
        uiCanvas.SetActive(true);
        uiplayer.text = PlayerPrefs.GetString("username");
    }

    public void Close() {
        uiCanvas.SetActive(false);
    }
    public void Logout() {
        uiCanvas.SetActive(false);
    }



   // -------------------------------------------------------------------------------------
   private void OnDestroy () {
      //Remove Listeners:
      uiCloseButton.onClick.RemoveListener (Close) ;
        uilogoutButton.onClick.RemoveListener(Logout);
      // Remove UI elements listeners :
      uiVibrationToggle.onValueChanged.RemoveListener (OnVibrationToggleChange) ;
      uiMusicSlider.onValueChanged.RemoveListener (OnMusicSliderChange) ;
      uiSoundsSlider.onValueChanged.RemoveListener (OnSoundsSliderChange) ;

   }
}
