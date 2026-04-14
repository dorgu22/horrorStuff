using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class MonologueUIScript : MonoBehaviour
{
    private UIDocument _document;
    private Label _monologueText;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _textSound;
    private bool canChangeText = true;

    private string[] texts = new string[]
    {
        "I knew you're not like other girls!",
        "Senya pidoras",
        "WAZAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA",
        ".. _.. ..    _. ._ .... .._ ..",
        "Evervess cola vanilla ice",
        "WAKA sea salt lemon",
        "minecraft.exe",
        "the girl in pink halls...",
        "the girl in a test tube...",
        "...",
        "йоу йоу йоу",
    };

    int textCount = 0;

    void Start()
    {
        _document = GetComponent<UIDocument>();
        _monologueText = _document.rootVisualElement.Q("monologueText") as Label;
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) && canChangeText)
        {
            canChangeText = false;
            StartCoroutine(TextPopPup(texts[textCount]));
        }

       
    }

    private IEnumerator TextPopPup(string text)
    {
        while (_monologueText.text != text)
        {
            _monologueText.text = string.Empty;

            foreach (char symbol in text)
            {
                _monologueText.text += symbol;
                _audioSource.PlayOneShot(_textSound, 0.5f);

                yield return new WaitForSeconds(0.02f);
            }
        }

        textCount++;

        canChangeText = true;

        yield return 0;
    }
}