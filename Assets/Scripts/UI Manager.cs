using UnityEngine;
using TMPro;
using Unity.Profiling;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private GameObject startMenuUI;
    [SerializeField] private GameObject gameOverUI;

    [SerializeField] private TextMeshProUGUI gameOverScoreUI;
    [SerializeField] private TextMeshProUGUI gameOverHighScoreUI;


    GameManager gm;

    void Start()
    {
        gm = GameManager.Instance;
        gm.onGameOver.AddListener(ActivteGameOverUI);
    }

    public void PlayButtonHandler ()
    {
        gm.StartGame();
        
    }

    private void ActivteGameOverUI()
    {
        gameOverUI.SetActive(true);
        gameOverScoreUI.text = "Score: " + gm.PrettyScore();
        gameOverHighScoreUI.text = "HighScore: " + gm.PrettyHighScore();
    }
    private void OnGUI()
    {
        scoreUI.text = gm.PrettyScore();
    }
}
