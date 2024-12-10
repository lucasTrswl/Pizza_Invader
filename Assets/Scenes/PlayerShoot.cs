using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Petite balle
    public GameObject largeBullet; // Grande balle
    public Camera mainCamera; // Référence à la caméra principale
    public float zoomSpeed = 2f; // Vitesse de zoom/dézoom
    public float minZoom = 5f; // Zoom minimum
    public float maxZoom = 20f; // Zoom maximum
    public float actionZoomThreshold = 15f; // Niveau de zoom pour déclencher l'action

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        // Gestion du zoom avec la molette
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0)
        {
            mainCamera.orthographicSize += scrollInput * zoomSpeed; // Inversé pour un zoom intuitif
            mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, minZoom, maxZoom);
        }
        
        // Gestion des tirs
        if (Input.GetMouseButtonDown(0))
        {
            if (mainCamera.orthographicSize <= actionZoomThreshold)
            {
                // Tir avec une grande balle (zoom proche)
                Instantiate(largeBullet, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            }
            else
            {
                // Tir avec une balle normale (zoom éloigné)
                Instantiate(bulletPrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            }
        }
    }
}
