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
        public DialogTrigger objectInteraction;
        public DialogTrigger dialogueTrigger;
        public bool interact;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            objectInteraction = collision.gameObject.GetComponent<DialogTrigger>();
            DisplayInteractionAction();
            interact = true;
        }

       void DisplayInteractionAction()
        {

        }

        private void Start()
        {
            var save = PersistentData.Instance;
            if (save.CurrentSanity > save.MaximumSanity)
                save.CurrentSanity = save.MaximumSanity;

            interact = false;
            dialogueTrigger = GetComponent<DialogTrigger>();
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
            // Reload Level (temp)
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
