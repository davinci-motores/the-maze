﻿using Game.Player;
using UnityEngine;

namespace Game.Objects.PowerUps
{
    public class SpeedPowerUpEffect : PowerUpEffect
    {
        [SerializeField] private float _speedMultiplier = 2f;
        //private GameObject _speedUIEffect;
        private float _playerSpeedDefault;
        private PlayerController player;
		
		protected override void ActivateEffect()
        {
            player = gameObject.GetComponentInParent<PlayerController>();
            _playerSpeedDefault = player.Speed;
            player.Speed = _playerSpeedDefault * _speedMultiplier;
            player.IsRunning(true);
            // _speedUIEffect.SetActive(true);
        }
        
        protected override void DesactivateEffect()
        {
            player.Speed = _playerSpeedDefault;
            player.IsRunning(false);
           // _speedUIEffect.SetActive(false);

        }
    }
}