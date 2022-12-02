using System;
using UnityEngine;

namespace Game.HUD
{
    public class PowerUpUI : MonoBehaviour
    {
        private SpriteRenderer powerUpSprite;

        private void Start()
        {
            powerUpSprite = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            
        }
    }
}