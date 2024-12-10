using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject largeBullet;
    public Camera mainCamera; // Référence à la caméra principale
    public float zoomSpeed = 2f; // Vitesse de zoom/dézoom
    public float minZoom = 5f; // Zoom minimum
    public float maxZoom = 15f; // Zoom maximum
    public float actionZoomThreshold = 7f; // La taille de la caméra à partir de laquelle l'action se déclenche

    private bool defaultState = true;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        // Obtenir l'entrée de la molette de la souris
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput != 0)
        {
            // Appliquer le zoom
            mainCamera.orthographicSize += scrollInput * zoomSpeed;
            mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, minZoom, maxZoom);
        }

        // Si on est zoomé à un niveau d'action, on permet de tirer avec une grande balle
        if (mainCamera.orthographicSize <= actionZoomThreshold)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Tir avec une grande balle
                Instantiate(bulletPrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            }
        }
        else
        {
            if (defaultState)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    // Tir avec une balle normale
                    Instantiate(largeBullet, transform.position + Vector3.up * 0.5f, Quaternion.identity);
                }
            }
            else
            {
                // Tir par défaut, mais aucun zoom
                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(largeBullet, transform.position + Vector3.up * 0.5f, Quaternion.identity);
                }
            }
        }
    }
}
