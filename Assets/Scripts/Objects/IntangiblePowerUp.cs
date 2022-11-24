using UnityEngine;
using Game.Player;

namespace Game.Objects
{
    public class IntangiblePowerUp : PowerUp
    {
        public override void Activate(PlayerController player)
        {
            player.gameObject.layer = 8;
        }
        public override void Desactivate(PlayerController player)
        {
            player.gameObject.layer = 7;
        }


    }

}
