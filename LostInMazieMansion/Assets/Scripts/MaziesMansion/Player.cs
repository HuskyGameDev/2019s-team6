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
        [Tooltip("The player's maximum health.")]
        public int MaximumHealth = 80;

        /// The player's current health.
        [SerializeField]
        private int _currentHealth;
        public int CurrentHealth
        {
            get => _currentHealth;
            set
            {
                _currentHealth = value;
                if(_currentHealth <= 0)
                    Die();
            }
        }

        /// Damage Modifier
        int Damage = 20;
        #endregion

        public CircleCollider2D playerCollider;
        public DialogueTrigger objectInteraction;
        public DialogueTrigger dialogueTrigger;
        public bool interact;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            objectInteraction = collision.gameObject.GetComponent<DialogueTrigger>();
            DisplayInteractionAction();
            interact = true;
        }

       void DisplayInteractionAction()
        {

        }

        private void Awake()
        {
            if (CurrentHealth <= 0)
                CurrentHealth = MaximumHealth;
        }

        private void Start()
        {
            interact = false;
            dialogueTrigger = GetComponent<DialogueTrigger>();
            playerCollider = GetComponent<CircleCollider2D>();
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

            if (Input.GetKeyDown("e") && interact && objectInteraction != null)
            {
                Debug.Log(objectInteraction);
                objectInteraction.TriggerDialogue();
            }
            else if (Input.anyKeyDown)
            {
                interact = false;
            }

        }

        private void Die()
        {
            // Reload Level
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag == "Enemy")
            {
                CurrentHealth -= Damage;
            }
        }
    }
}
