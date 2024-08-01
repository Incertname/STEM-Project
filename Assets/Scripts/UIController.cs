using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private Image _heartImage;
    private TextMeshProUGUI _coinText;
    private GameObject _menuPanel;
    public Slider _sfxSlider;
    public Slider _musicSlider;

    private int _coinCount = 0;
    public AudioSourceController _audioSourceController;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find(Structs.UI.heartImage))
        {
            _heartImage = GameObject.Find(Structs.UI.heartImage).GetComponent<Image>(); HeartImageUpdate(1);
            HeartImageUpdate(1);
        }
        if (GameObject.Find(Structs.UI.coinText))
        {
            _coinText = GameObject.Find(Structs.UI.coinText).GetComponent<TextMeshProUGUI>();
        }

        if (GameObject.Find(Structs.UI.coins))
        {
            _coinCount = GameObject.Find(Structs.UI.coins).transform.childCount;
            CoinTextUpdate(0);
        }
        _menuPanel = GameObject.Find(Structs.UI.menuPanel);
        

        _menuPanel.SetActive(false);

        SetSliders();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (_menuPanel.active)
            {
                _menuPanel.SetActive(false);
            }
            else
            {
                _menuPanel.SetActive(true);
            }

        }
    }
    public void BackButton()
    {
        _menuPanel.SetActive(false);
    }

    public void OptionsButton()
    {
        _menuPanel.SetActive(true);
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(Structs.Scenes.menu);
    }

    public void FirstLevelButton()
    {
        SceneManager.LoadScene(Structs.Scenes.firstLevel);
    }

    public void HeartImageUpdate(float newAmount)
    {
        _heartImage.fillAmount = newAmount;
    }

    public void CoinTextUpdate(int newAmount)
    {
        _coinText.text = newAmount + " / " + _coinCount;
    }

    public void SetSliders()
    {
        _sfxSlider.value = PlayerPrefs.GetFloat(Structs.Mixers.sfxVolume);
        _musicSlider.value = PlayerPrefs.GetFloat(Structs.Mixers.musicVolume);
    }
    public void UpdateSFXSLider()
    {
        Debug.Log((_audioSourceController == null) + " CHeck ");
        _audioSourceController.UpdateSFXGroup(_sfxSlider.value);
    }
    public void UpdateMusicSLider()
    {
        _audioSourceController.UpdateMusicGroup(_musicSlider.value);
    }

}
