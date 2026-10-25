using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;

    GameManager gm;
    
    void Start()
    {
        gm = GameManager.Instance;
    }

    private void OnGUI()
    {
        scoreUI.text = gm.PrettyScore();
    }
}
