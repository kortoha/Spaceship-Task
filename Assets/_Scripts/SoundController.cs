using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance { get; private set; }

    [SerializeField] private Button _soundButton;
    [SerializeField] private Image _soundImage;
    [SerializeField] private Sprite _onSprite;
    [SerializeField] private Sprite _offSprite;

    private bool _isSoundPlay = false;
    private const string SoundKey = "SoundState";

    private AudioSource _clickSound;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _clickSound = GetComponent<AudioSource>();

        _isSoundPlay = PlayerPrefs.GetInt(SoundKey, 0) == 1;
        UpdateSoundState();
        _soundButton.onClick.AddListener(OnOffSound);
    }

    private void OnOffSound()
    {
        _clickSound.Play();
        _isSoundPlay = !_isSoundPlay;
        UpdateSoundState();
        PlayerPrefs.SetInt(SoundKey, _isSoundPlay ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void UpdateSoundState()
    {
        _soundImage.sprite = _isSoundPlay ? _offSprite : _onSprite;
        AudioListener.pause = _isSoundPlay;
    }

    public void PlayClickSound()
    {
        _clickSound.Play();
    }
}
