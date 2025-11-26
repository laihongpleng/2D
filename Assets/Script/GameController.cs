using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // For TextMeshPro

public class GameController : MonoBehaviour
{
    [Header("UI Elements")]
    public Image playerImage;
    public Image computerImage;
    public TMP_Text resultText;

    [Header("Score Texts")]
    public TMP_Text playerScoreText;
    public TMP_Text computerScoreText;

    [Header("Sprites")]
    public Sprite rockSprite;
    public Sprite paperSprite;
    public Sprite scissorsSprite;

    private int playerScore = 0;
    private int computerScore = 0;

    private enum Choice { None = 0, Rock = 1, Paper = 2, Scissors = 3 }

    public void OnButtonClick(GameObject buttonObject)
    {
        // Safety check
        if(playerImage == null || computerImage == null || resultText == null ||
           playerScoreText == null || computerScoreText == null ||
           rockSprite == null || paperSprite == null || scissorsSprite == null)
        {
            Debug.LogError("Assign all UI elements and sprites in the Inspector!");
            return;
        }

        // Extract player choice from button name (e.g., "1_Rock")
        Choice playerChoice = (Choice)int.Parse(buttonObject.name.Split('_')[0]);

        // Update player image
        playerImage.sprite = GetSprite(playerChoice);

        // Random computer choice
        Choice computerChoice = (Choice)Random.Range(1, 4);
        computerImage.sprite = GetSprite(computerChoice);

        // Check result
        string result = GetResult(playerChoice, computerChoice);

        // Update result text
        resultText.text = result;

        // Update scores as numbers only
        playerScoreText.text = playerScore.ToString();
        computerScoreText.text = computerScore.ToString();
    }

    // Return the corresponding sprite for each choice
    Sprite GetSprite(Choice choice)
    {
        switch (choice)
        {
            case Choice.Rock: return rockSprite;
            case Choice.Paper: return paperSprite;
            case Choice.Scissors: return scissorsSprite;
            default: return null;
        }
    }

    // Determine the game result and update scores
    string GetResult(Choice player, Choice computer)
    {
        if (player == computer) return "Draw!";

        if ((player == Choice.Rock && computer == Choice.Scissors) ||
            (player == Choice.Paper && computer == Choice.Rock) ||
            (player == Choice.Scissors && computer == Choice.Paper))
        {
            playerScore++;
            return "You Win!";
        }
        else
        {
            computerScore++;
            return "You Lose!";
        }
    }
    
}
