using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject Player;
    public Vector3 originalPos;
    public Camera camera;
    public float minZoomForFollow = 7.2f;

    private void Start()
    {
        Player = GameObject.Find("Player");
        originalPos = transform.position;
        camera = gameObject.GetComponent<Camera>();
    }
    private void Update()
    {
        if (camera.orthographicSize <= minZoomForFollow) {
            transform.position = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);
        } else
        {
            transform.position = originalPos;
        }
    }
}