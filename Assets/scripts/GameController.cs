using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI References")]
    public Image yourChoiceImage;
    public Image comChoiceImage;
    public TextMeshProUGUI yourScoreText;
    public TextMeshProUGUI comScoreText;
    public TextMeshProUGUI resultText;

    [Header("Sprites")]
    public Sprite rockSprite;
    public Sprite paperSprite;
    public Sprite scissorsSprite;

    private int yourScore = 0;
    private int comScore = 0;

    // Static variables to pass data to GameOver scene
    public static int finalPlayerScore;
    public static int finalComputerScore;
    public static string gameResult; // "WIN", "LOSE", or "DRAW"

    void Start()
    {
        // Reset scores when starting new game
        yourScore = 0;
        comScore = 0;
        yourScoreText.text = "0";
        comScoreText.text = "0";
        resultText.text = "Choose your move!";
    }

    public void PlayerChoose(int you)
    {
        // Set player sprite
        yourChoiceImage.sprite = GetSprite(you);

        // Random computer choice 1–3
        int com = Random.Range(1, 4);
        comChoiceImage.sprite = GetSprite(com);

        // Determine result
        int k = you - com;

        if (k == 0)
        {
            resultText.text = "Draw!";
        }
        else if (k == 1 || k == -2)
        {
            resultText.text = "You Win!";
            yourScore++;
        }
        else
        {
            resultText.text = "Computer Wins!";
            comScore++;
        }

        // Update score text
        yourScoreText.text = yourScore.ToString();
        comScoreText.text = comScore.ToString();
    }

    public void EndGame()
    {
        // Determine final result
        if (yourScore > comScore)
        {
            gameResult = "WIN";
        }
        else if (comScore > yourScore)
        {
            gameResult = "LOSE";
        }
        else
        {
            gameResult = "DRAW";
        }

        // Store final scores
        finalPlayerScore = yourScore;
        finalComputerScore = comScore;

        // Load game over scene
        SceneManager.LoadScene("GameOver");
    }

    // Return correct sprite
    Sprite GetSprite(int num)
    {
        return num switch
        {
            1 => rockSprite,
            2 => paperSprite,
            3 => scissorsSprite,
            _ => null,
        };
    }
}