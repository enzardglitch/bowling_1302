using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text textScore;
    [SerializeField]
    TMP_Text textRound;
    [SerializeField]
    TMP_Text textAccuracy;
    public static UIManager instance;



    public void Awake()
    {
        instance = this;
    }

    public void UpdateScore(int score)
    {
        textScore.text = $"Score: {score}";
    }

    public void UpdateRound(int round, int scores)
    {
        textRound.text = $"Round: {round}";
        if (round == 0)
        {
            textAccuracy.text = $"Accuracy: 0%";
        }
        else
        {
            textAccuracy.text = $"Accuracy: {(float)scores / (round * 10) * 100}%";
        }
  
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
