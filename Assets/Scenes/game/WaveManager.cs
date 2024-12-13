using UnityEngine;
using TMPro;
using UnityEngine.VFX;
using System.Linq;
using System;

public class WaveManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform spawnPoint;
    public int currentWave = 1;
    public int enemiesPerWave = 1;
    public int pointsPerWave = 10;
    public float spawnRadius = 2f;
    public Vector2[] firstRowSpawns; // impaire
    public Vector2[] secondRowSpawns; // pair

    public TMP_Text waveText;  // Référence publique pour le texte de la vague (TextMeshPro)
    public TMP_Text pointsText;  // Référence publique pour le texte des points (TextMeshPro)

    private int enemiesRemaining;
    private int totalPoints = 0;

    public PlayerHealth playerHealth;  // Référence à la santé du joueur
    public PlayerShoot playerShoot;    // Réf fusil joueur
    public GameObject EnemyGroup;

    void Start()
    {
        StartWave();
    }

    void StartWave()
    {
        enemiesRemaining = enemiesPerWave;

        Vector2[] positions = GetCentered(secondRowSpawns, firstRowSpawns, enemiesPerWave);
        
        foreach (Vector2 position in positions)
        {
            SpawnEnemy(position);
        }

        playerShoot.reloadTime += playerShoot.reloadTimeIncrement;

    }

    void SpawnEnemy(Vector2 spawnPosition)
    {

        GameObject enemyPrefab = enemyPrefabs[UnityEngine.Random.Range(0, enemyPrefabs.Length)];

        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemy.transform.SetParent(EnemyGroup.transform);
    }

    public void EnemyDefeated()
    {
        enemiesRemaining--;

        if (enemiesRemaining <= 0)
        {
            totalPoints += pointsPerWave;
            currentWave++;

            if (enemiesPerWave < firstRowSpawns.Length + secondRowSpawns.Length)
            {
                enemiesPerWave++;
            }

            // Le joueur récupère une vie à la fin de chaque vague
            if (playerHealth != null)
            {
                playerHealth.Heal(1);  // Le joueur récupère 1 vie
            }

            StartWave();
        }
    }

    void Update()
    {
        // Mettre à jour les informations de l'UI avec TextMeshPro
        waveText.text = "" + currentWave;
        pointsText.text = "" + totalPoints;
    }

    // Utile pour placer les enemis au centre
    Vector2[] GetCentered(Vector2[] firstRowSpawns, Vector2[] secondRowSpawns, int enemiesPerWave)
    {
        // Lengths of the two arrays
        int firstArrayLength = firstRowSpawns.Length;
        int secondArrayLength = secondRowSpawns.Length;

        // Total number of enemies to spawn
        int totalEnemies = enemiesPerWave;

        // Create a list to store the final selected positions
        var selectedPositions = new System.Collections.Generic.List<Vector2>();

        // First, try to center the selection in the first array
        int startIndexFirst = (firstArrayLength - totalEnemies) / 2;
        int endIndexFirst = startIndexFirst + totalEnemies;

        // Check bounds for the first array and select the positions from it
        if (startIndexFirst >= 0 && endIndexFirst <= firstArrayLength)
        {
            selectedPositions.AddRange(firstRowSpawns.Skip(startIndexFirst).Take(totalEnemies));
        }
        else
        {
            // If the entire range can't fit in the first array, take as many as possible from the first array
            selectedPositions.AddRange(firstRowSpawns.Skip(startIndexFirst).Take(firstArrayLength - startIndexFirst));

            // Calculate how many remaining positions we need to fill from the second array
            totalEnemies -= selectedPositions.Count;

            // Now, select from the second array
            int startIndexSecond = (secondArrayLength - totalEnemies) / 2;
            selectedPositions.AddRange(secondRowSpawns.Skip(startIndexSecond).Take(totalEnemies));
        }

        // Return the final selected positions
        return selectedPositions.ToArray();
    }
}
