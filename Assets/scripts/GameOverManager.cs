using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI computerScoreText;

    [Header("Icons")]
    public Image playerIcon;
    public Image computerIcon;

    void Start()
    {
        DisplayResults();
    }

    void DisplayResults()
    {
        // Display scores
        playerScoreText.text = GameManager.finalPlayerScore.ToString();
        computerScoreText.text = GameManager.finalComputerScore.ToString();

        // Display result message
        switch (GameManager.gameResult)
        {
            case "WIN":
                resultText.text = "YOU WIN!";
                resultText.color = Color.green;
                break;
            case "LOSE":
                resultText.text = "YOU LOSE!";
                resultText.color = Color.red;
                break;
            case "DRAW":
                resultText.text = "DRAW!";
                resultText.color = Color.yellow;
                break;
        }
    }

    public void StartOver()
    {
        SceneManager.LoadScene("GameScene");
    }
}