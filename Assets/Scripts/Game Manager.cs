using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    
    #region Singleton

    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    #endregion

    public float currentScore = 0f;
    public SaveData saveData;
    public bool isPlaying = false;
    public UnityEvent onPlay = new UnityEvent();
    public UnityEvent onGameOver = new UnityEvent();


    void Start()
    {
       
        string loadedData = SaveSystem.Load("save");
        if (loadedData != null)
        {
            saveData = JsonUtility.FromJson<SaveData>(loadedData);
        }
        else
        {
            saveData = new SaveData();
        }
        
       
        
    }
    private void Update()
    {
        if (isPlaying)
        {
            currentScore += Time.deltaTime;
        }
    }

    public void StartGame()
    {
        onPlay.Invoke();
        isPlaying = true;
        currentScore = 0;
    }

    public void GameOver()
    {
        
        if(saveData.highScore < currentScore)
        {
            saveData.highScore = currentScore;

            string saveString = JsonUtility.ToJson(saveData);

            SaveSystem.Save("save", saveString);
        }
        
        isPlaying = false;
        onGameOver.Invoke();
    }
    public string PrettyScore()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }

    public string PrettyHighScore()
    {
        return Mathf.RoundToInt(saveData.highScore).ToString();
    }
}
