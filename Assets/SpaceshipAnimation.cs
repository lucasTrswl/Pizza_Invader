using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpaceshipAnimation : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite spriteA;
    public Sprite spriteB;
    public float spriteADuration;
    public float spriteBDuration;
    public bool isSpriteA = true;
    private float timer;

    private void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0) {
            isSpriteA = !isSpriteA;
            spriteRenderer.sprite = isSpriteA ? spriteA : spriteB;
            ResetTimer();
        }
    }

    void ResetTimer()
    {
        timer = isSpriteA ? spriteADuration : spriteBDuration;
    }
}
