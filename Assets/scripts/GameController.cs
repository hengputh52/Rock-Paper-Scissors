using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Image yourChoiceImage;
    public Image comChoiceImage;

    public Sprite rockSprite;
    public Sprite paperSprite;
    public Sprite scissorsSprite;

    public TextMeshProUGUI yourScoreText;
    public TextMeshProUGUI comScoreText;
    public TextMeshProUGUI resultText;

    private int yourScore = 0;
    private int comScore = 0;

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
        yourScoreText.text = ""+yourScore;
        comScoreText.text = ""+comScore;
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
