using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform spawnPoint;
    public int currentWave = 1;
    public int enemiesPerWave = 1;
    public int pointsPerWave = 10;
    public float spawnRadius = 2f;

    public TMP_Text waveText;  // Référence publique pour le texte de la vague (TextMeshPro)
    public TMP_Text pointsText;  // Référence publique pour le texte des points (TextMeshPro)

    private int enemiesRemaining;
    private int totalPoints = 0;

    public PlayerHealth playerHealth;  // Référence à la santé du joueur

    void Start()
    {
        StartWave();
    }

    void StartWave()
    {
        enemiesRemaining = enemiesPerWave;
        for (int i = 0; i < enemiesPerWave; i++)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Vector3 spawnPosition = spawnPoint.position + new Vector3(Random.Range(-spawnRadius, spawnRadius), Random.Range(-spawnRadius, spawnRadius), 0);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    public void EnemyDefeated()
    {
        enemiesRemaining--;

        if (enemiesRemaining <= 0)
        {
            totalPoints += pointsPerWave;
            currentWave++;
            enemiesPerWave++;

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
}
