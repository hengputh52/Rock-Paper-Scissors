using UnityEngine;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour
{
    [Header("Button Choice Value")]
    public int choiceValue; // 1 = Rock, 2 = Paper, 3 = Scissors

    private Button button;
    private GameManager gameManager;

    void Start()
    {
        // Get the Button component
        button = GetComponent<Button>();
        
        // Find the GameManager in the scene
        gameManager = FindObjectOfType<GameManager>();
        
        // Add click listener
        if (button != null && gameManager != null)
        {
            button.onClick.AddListener(OnButtonClicked);
        }
        else
        {
            Debug.LogError("Button or GameManager not found!");
        }
    }

    private void OnButtonClicked()
    {
        // Call the GameManager's PlayerChoose method with this button's choice value
        gameManager.PlayerChoose(choiceValue);
    }
}   