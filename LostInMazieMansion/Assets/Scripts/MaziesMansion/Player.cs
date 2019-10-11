using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaziesMansion
{

    [RequireComponent(typeof(Animator))]
    internal sealed class Player : MonoBehaviour
    {
#region MovementData
        private Animator Animator;

        public float MoveSpeed = 3;
#endregion

#region HealthData
        /// The player's current health.
        public int CurrentHealth
        {
            get => PersistentData.Instance.CurrentSanity;
            set
            {
                PersistentData.Instance.CurrentSanity = value;
                if(value <= 0)
                    Die();
            }
        }

        /// Damage Modifier
        int Damage = 20;
        #endregion

        public CircleCollider2D playerCollider;
        public Rigidbody2D rb2D;
        public CharacterController characterController;

        private Interactable _interactable;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.gameObject.tag == "Enemy")
            {
                CurrentHealth -= Damage;
            }
        }

        private void Start()
        {
            var save = PersistentData.Instance;
            if (save.CurrentSanity > save.MaximumSanity)
                save.CurrentSanity = save.MaximumSanity;

            playerCollider = GetComponent<CircleCollider2D>();
            rb2D = gameObject.GetComponent<Rigidbody2D>();
            characterController = GetComponent<CharacterController>();
            Animator = GetComponent<Animator>();
        }

        private void Update()
        {
            var xMovement = Input.GetAxisRaw("Horizontal");
            var yMovement = Input.GetAxisRaw("Vertical");

            var movementVector = new Vector3(0, 0, 0);
            if(Mathf.Abs(xMovement) > 0.5f)
                movementVector.x = xMovement * MoveSpeed * Time.deltaTime;
            if(Mathf.Abs(yMovement) > 0.5f)
                movementVector.y = yMovement  * MoveSpeed * Time.deltaTime;

            Animator.SetFloat("Move X", xMovement);
            Animator.SetFloat("Move Y", yMovement);
            if(movementVector.sqrMagnitude > 0)
            {
                transform.Translate(movementVector);
                Animator.SetBool("PlayerMoving", true);
                Animator.SetFloat("LastMoveX", Mathf.Abs(movementVector.y) > 0.5f ? 0 : movementVector.x);
                Animator.SetFloat("LastMoveY", movementVector.y);

            } else
            {
                Animator.SetBool("PlayerMoving", false);
            }

            if (Input.GetKeyDown("e") && null != _interactable)
                _interactable.OnPlayerInteracts?.Invoke();
        }

        private void Die()
        {
            // revert to default save (temp)
            SaveUtility.LoadGame(PersistentData.Default);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag == "Enemy")
            {
                CurrentHealth -= Damage;
            }
            if(other.TryGetComponent<Interactable>(out var interactable))
            {
                _interactable = interactable;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _interactable = null;
        }
    }
}
