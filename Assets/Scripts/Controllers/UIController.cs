using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button restartButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button mainMenuButton2;

    void Awake()
    {
        if (playButton != null)
        {
            playButton.onClick.AddListener(PlayGame);
        }

        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);
        }

        if (mainMenuButton != null)
        {
            mainMenuButton.onClick.AddListener(BackToMainMenu);
            mainMenuButton2.onClick.AddListener(BackToMainMenu);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void PlayGame()
    {
        GameManager.Instance.PlayGame();
    }

    void RestartGame()
    {
        GameManager.Instance.RestartGame();
    }

    void BackToMainMenu()
    {
        GameManager.Instance.BackToMainMenu();
    }
}
