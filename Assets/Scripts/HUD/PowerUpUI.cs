using UnityEngine;
using UnityEngine.UI;

namespace Game.HUD
{
    public class PowerUpUI : MonoBehaviour
    {
        [SerializeField] private Image _backGround;
        [SerializeField] private Color _defaultColor;

        public void SetDefaultColor()
        {
            _backGround.color = _defaultColor;
        }

        public void SetColor(Color color)
        {
            _backGround.color = color;
        }
    }
}