using UnityEngine;
using Game.Player;

namespace Game.Objects
{
    public class IntangiblePowerUp : PowerUp
    {
        public override void Activate(PlayerController player)
        {
            Debug.Log("Mira Atravieso paredes");
        }
        public override void Desactivate(PlayerController player)
        {
            Debug.Log("Ya no mas");
        }


    }

}
