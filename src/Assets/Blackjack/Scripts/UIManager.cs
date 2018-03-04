using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Image _audioImage;
    private Sprite _audioOnSprite;

    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Button _dealButton;
    [SerializeField]
    private Button _hitButton;
    [SerializeField]
    private Button _standButton;
    [SerializeField]
    private Button _newGameButton;
    [SerializeField]
    private Button _exitButton;
    [SerializeField]
    private Button _audioButton;
    [SerializeField]
    private Sprite _audioOffSprite;
    [SerializeField]
    private NotificationHandler _notificationHandler;

    public delegate void ButtonEvent();
    public event ButtonEvent OnDealButtonEvent = delegate { };
    public event ButtonEvent OnHitButtonEvent = delegate { };
    public event ButtonEvent OnStandButtonEvent = delegate { };
    public event ButtonEvent OnNewGameButtonEvent = delegate { };
    public event ButtonEvent OnExitButtonEvent = delegate { };

    public delegate bool ButtonEventWithBoolean();
    public event ButtonEventWithBoolean OnAudioButtonEvent = delegate() { return false; };

    public NotificationHandler NotificationHandler {
        get {
            return _notificationHandler;
        }
    }

    private void Start()
    {
        _dealButton.onClick.AddListener(() => OnDealButtonEvent());
        _hitButton.onClick.AddListener(() => OnHitButtonEvent());
        _standButton.onClick.AddListener(() => OnStandButtonEvent());
        _newGameButton.onClick.AddListener(() => OnNewGameButtonEvent());
        _exitButton.onClick.AddListener(() => OnExitButtonEvent());

        _audioButton.onClick.AddListener(OnAudioButtonClick);
        _audioImage = _audioButton.GetComponent<Image>();
        _audioOnSprite = _audioImage.sprite;

        _notificationHandler.Setup();
    }

    public void OnUpdateGameplayButtons(GameAction action)
    {
        _dealButton.interactable = (action == GameAction.Deal);
        _hitButton.interactable = (action == GameAction.HitAndStand);
        _standButton.interactable = (action == GameAction.HitAndStand);
        _newGameButton.interactable = (action == GameAction.NewGame);
    }

    public void UpdateScore(int humanScore, int computerScore)
    {
        _scoreText.text = string.Format("Player: {0}\nComputer: {1}", humanScore, computerScore);
    }

    private void OnAudioButtonClick()
    {
        bool _isAudioDisabled = OnAudioButtonEvent();

        if (_isAudioDisabled) {
            _audioImage.sprite = _audioOffSprite;
        }
        else {
            _audioImage.sprite = _audioOnSprite;
        }
    }
}