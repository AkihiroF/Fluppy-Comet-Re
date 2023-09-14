using UnityEngine;

namespace _Source.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovementComponent : MonoBehaviour, IMovablePlayer
    {
        [SerializeField] private float speedMovement;
        [SerializeField] private float velocityForce;
        [SerializeField] private Vector2 maxVelocity;
        private Rigidbody2D _rb;
        private Vector2 _vectorUp = Vector2.zero;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void OnJump(bool isActive)
        {
            if (isActive)
            {
                _vectorUp = Vector2.up * velocityForce;
            }
            else
            {
                _vectorUp = Vector2.zero;
            }
        }

        private void FixedUpdate()
        {
            Vector2 vectorMoving = Vector2.right * speedMovement + _vectorUp;
            _rb.AddForce(vectorMoving);

            Vector2 currentVelocity = _rb.velocity;
            currentVelocity.x = Mathf.Clamp(currentVelocity.x, -maxVelocity.x, maxVelocity.x);
            currentVelocity.y = Mathf.Clamp(currentVelocity.y, -maxVelocity.y, maxVelocity.y);

            _rb.velocity = currentVelocity;
        }
    }
}