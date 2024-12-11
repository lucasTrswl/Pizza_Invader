using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Le prefab du projectile
    public float minShootInterval = 1.0f; // Intervalle minimum entre les tirs
    public float maxShootInterval = 3.0f; // Intervalle maximum entre les tirs

    private float shootTimer; // Temps restant avant le prochain tir

    // Start is called before the first frame update
    void Start()
    {
        // Initialisation du timer de tir avec un intervalle aléatoire
        ResetShootTimer();
    }

    // Update is called once per frame
    void Update()
    {
        // Réduit le timer à chaque frame
        shootTimer -= Time.deltaTime;

        // Si le timer atteint zéro, l'ennemi tire
        if (shootTimer <= 0)
        {
            Shoot();
            // Réinitialise le timer avec une nouvelle valeur aléatoire pour le prochain tir
            ResetShootTimer();
        }
    }

    void Shoot()
    {
        // Crée la balle à la position de l'ennemi
        Instantiate(bulletPrefab, transform.position + Vector3.down * 0.5f, Quaternion.identity);
    }

    void ResetShootTimer()
    {
        // Réinitialise le timer avec une valeur aléatoire entre les intervalles définis
        shootTimer = Random.Range(minShootInterval, maxShootInterval);
    }
}
