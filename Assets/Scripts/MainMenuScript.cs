using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private UIDocument _document;
    private Button _startGameButton, _settingsButton, _exitGameButton;
    private List<Button> _menuButtons = new List<Button>();
    private AudioSource audioSource, backgroundMusicAudioSource;
    private VisualElement _blackOutScreen, _logo, _productionName;
    [SerializeField] private GameObject backgroundMusic;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        backgroundMusicAudioSource = backgroundMusic.GetComponent<AudioSource>();

        _document = GetComponent<UIDocument>();
        _startGameButton = _document.rootVisualElement.Q("StartGameButton") as Button;
        _startGameButton.RegisterCallback<ClickEvent>(OnStartGameButtonClick);

        _settingsButton = _document.rootVisualElement.Q("SettingsButton") as Button;
        _settingsButton.RegisterCallback<ClickEvent>(OnSettingsButtonClick);

        _exitGameButton = _document.rootVisualElement.Q("ExitGameButton") as Button;
        _exitGameButton.RegisterCallback<ClickEvent>(OnExitGameButtonClick);

        // надо оптимизировать кнопки, что бы они все в лист записывались (учитываю кнопки в настройках и тд) и привязать к ним функции

        _menuButtons = _document.rootVisualElement.Query<Button>().ToList();

        _blackOutScreen = _document.rootVisualElement.Q("Container2") as VisualElement;
        _logo = _document.rootVisualElement.Q("LogoImage") as Image;
        _productionName = _document.rootVisualElement.Q("ProductionNameLabel") as Label;

        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].RegisterCallback<ClickEvent>(OnButtonClick);
            _menuButtons[i].SetEnabled(false);
        }

        _logo.style.opacity = 0;
        _productionName.style.opacity = 0;
    }

    private void Start()
    {
        StartCoroutine(Intro());
    }

    private void OnDisable()
    {
        _startGameButton.UnregisterCallback<ClickEvent>(OnStartGameButtonClick);
        _settingsButton.UnregisterCallback<ClickEvent>(OnSettingsButtonClick);
        _exitGameButton.UnregisterCallback<ClickEvent>(OnExitGameButtonClick);

        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].UnregisterCallback<ClickEvent>(OnButtonClick);
        }
    }

    private void OnStartGameButtonClick(ClickEvent clickEvent)
    {
        StartCoroutine(StartGame());
    }
    private void OnSettingsButtonClick(ClickEvent clickEvent)
    {
        Debug.Log("Settings");
    }
    private void OnExitGameButtonClick(ClickEvent clickEvent)
    {
        Application.Quit();
    }

    private void OnButtonClick(ClickEvent clickEvent)
    {
        audioSource.Play();
    }

    private IEnumerator Intro()
    {
        StyleFloat styleFloat = new StyleFloat(0f);

        yield return new WaitForSeconds(3);

        while (_logo.resolvedStyle.opacity < 1)
        {
            styleFloat.value += 0.02f - Time.deltaTime;
            _logo.style.opacity = styleFloat;
            _productionName.style.opacity = styleFloat;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1);

        while (_logo.resolvedStyle.opacity > 0)
        {
            styleFloat.value -= 0.02f - Time.deltaTime;
            _logo.style.opacity = styleFloat;
            _productionName.style.opacity = styleFloat;
            yield return new WaitForSeconds(0.05f);
        }

        styleFloat.value = 1.0f;

        yield return new WaitForSeconds(1);

        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].SetEnabled(true);
        }

        while (_blackOutScreen.resolvedStyle.opacity > 0.0f)
        {
            styleFloat.value -= 0.01f - Time.deltaTime;
            _blackOutScreen.style.opacity = styleFloat;
            yield return new WaitForSeconds(0.05f);
        }


        yield return 0;
    }

    private IEnumerator StartGame()
    {
        foreach (var button in _menuButtons)
            button.SetEnabled(false);

        StyleFloat styleFloat = new StyleFloat(1.0f);

        while(backgroundMusicAudioSource.volume > 0)
        {
            backgroundMusicAudioSource.volume -= 0.01f - Time.deltaTime;

            foreach (var button in _menuButtons)
            {
                styleFloat.value -= 0.01f - Time.deltaTime;
                button.style.opacity = styleFloat;
            }

            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(3.0f);

        SceneManager.LoadScene("MonologueScene");

        yield return 0;
    }
}