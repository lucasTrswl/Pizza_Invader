using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject Player;
    public PlayerShoot playerShoot;
    public Vector3 originalPos;
    public Camera camera;

    private void Start()
    {
        Player = GameObject.Find("Player");
        playerShoot = Player.GetComponent<PlayerShoot>();
        originalPos = transform.position;
        camera = gameObject.GetComponent<Camera>();
    }
    private void Update()
    {
        if (playerShoot.isBigBullet) {
            transform.position = new Vector3(Player.transform.position.x, originalPos.y + 0.7f, originalPos.z);
        } else
        {
            transform.position = originalPos;
        }
    }
}