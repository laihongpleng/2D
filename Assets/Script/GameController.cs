using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("UI Elements")]
    public Image playerImage;
    public Image computerImage;
    public Text resultText;
    public Text scoreText;

    [Header("Sprites")]
    public Sprite rockSprite;
    public Sprite paperSprite;
    public Sprite scissorsSprite;

    private int playerScore = 0;
    private int computerScore = 0;

    private enum Choice { None = 0, Rock = 1, Paper = 2, Scissors = 3 }

    public void OnButtonClick(GameObject buttonObject)
    {
        // Extract player choice from button name
        Choice playerChoice = (Choice)int.Parse(buttonObject.name.Split('_')[0]);

        // Update player image
        playerImage.sprite = GetSprite(playerChoice);

        // Random computer choice
        Choice computerChoice = (Choice)Random.Range(1, 4);
        computerImage.sprite = GetSprite(computerChoice);

        // Check result
        string result = GetResult(playerChoice, computerChoice);

        // Update result and score text
        resultText.text = result;
        scoreText.text = $"Player: {playerScore}  |  Computer: {computerScore}";
    }

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
