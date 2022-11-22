using UnityEngine;
using UnityEngine.InputSystem;
using Quaternion = UnityEngine.Quaternion;

namespace Game.Player.Camera
{
    public class RotationCameraController : MonoBehaviour
    {
        [SerializeField] private Transform _followTarget;
        [SerializeField] private float _rotationXSpeed = 2f;
        private Vector2 _lookVector;

        public void Look(InputAction.CallbackContext context)
        {
            _lookVector = context.ReadValue<Vector2>();
        }

        private void Update()
        {
            _followTarget.rotation *= Quaternion.AngleAxis(_lookVector.x * _rotationXSpeed, Vector3.up);
        }
    }
}