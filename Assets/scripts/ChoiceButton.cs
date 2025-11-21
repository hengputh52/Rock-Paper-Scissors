using UnityEngine;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour
{
    public int choiceNumber; // 1=Rock, 2=Paper, 3=Scissors

    public GameManager gameManager;

    public void OnClickButton()
    {
        gameManager.PlayerChoose(choiceNumber);
    }
}
