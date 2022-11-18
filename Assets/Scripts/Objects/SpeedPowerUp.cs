using Game.Player;
using UnityEngine;

namespace Game.Objects
{
    public class SpeedPowerUp : PowerUp
    {
        public override void Activate(PlayerController player)
        {
            Debug.Log("aumenta");
        }
        
        public override void Desactivate(PlayerController player)
        {
            Debug.Log("default");
        }
    }
}