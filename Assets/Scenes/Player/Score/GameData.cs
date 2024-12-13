using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{

    public static int PlayerScore; // Stocke le score du joueur
    public static int BestScore;
    
    public static void Init() {
        PlayerScore = 0;
        BestScore = PlayerPrefs.GetInt("best");
    }
    public static void AddScore(int points) {
        PlayerScore += points;
        if (BestScore < PlayerScore) {
            BestScore = PlayerScore;
        }
    }

    public static void Save() {
        PlayerPrefs.SetInt("score", PlayerScore);
        PlayerPrefs.SetInt("best", BestScore);
    }
}
