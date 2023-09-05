using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovementComponent : MonoBehaviour
    {
        [SerializeField] private float speedMovement;
        [SerializeField] private float velocityForce;
        [SerializeField] private Vector2 maxVelocity;
        private Rigidbody2D _rb;
        private Vector2 _vectorUp;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void OnJump(bool isActive)
        {
            _vectorUp = isActive ? Vector2.up * velocityForce : Vector2.zero;
        }

        private void FixedUpdate()
        {
            var vectorMoving = Vector2.right * speedMovement + _vectorUp;
            _rb.AddForce(vectorMoving);
            var currentVelocity = _rb.velocity;
            if (_rb.velocity.x > maxVelocity.x)
                currentVelocity.x = maxVelocity.x;
            if (_rb.velocity.y > maxVelocity.y)
                currentVelocity.y = maxVelocity.y;

            _rb.velocity = currentVelocity;
        }
    }
}