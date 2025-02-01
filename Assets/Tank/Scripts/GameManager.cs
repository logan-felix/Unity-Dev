using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject winUI;
    [SerializeField] GameObject loseUI;

    enum eState
    {
        TITLE, GAME, PAUSE, WIN, LOSE
    }

    eState state = eState.TITLE;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        pauseUI.SetActive(false);
        winUI.SetActive(false);
        loseUI.SetActive(false);
    }

    void Update()
    {
        switch (state)
        {
            case eState.TITLE:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    OnStartGame();
                }
                break;
            case eState.GAME:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Pause();
                }
                break;
            case eState.PAUSE:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Resume();
                }
                break;
            case eState.WIN:
                break;
            case eState.LOSE:
                break;
            default:
                break;
        }
        if (state != eState.GAME)
        {
            gameObject.GetComponent<PlayerTank>().isPaused = true;
        }
        else
        {
            gameObject.GetComponent<PlayerTank>().isPaused = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            titleUI.SetActive(false);
        }
    }

    public void OnStartGame()
    {
        titleUI.SetActive(false);
        state = eState.GAME;
    }

    public void Pause()
    {
        pauseUI.SetActive(true);
        state = eState.PAUSE;
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        state = eState.GAME;
    }

    public void SetWin()
    {
        winUI.SetActive(true);
        state = eState.WIN;
    }

    public void SetGameOver()
    {
        loseUI.SetActive(true);
        state = eState.LOSE;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
