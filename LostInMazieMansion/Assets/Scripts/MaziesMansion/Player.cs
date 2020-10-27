using System;
using System.Collections;
using MaziesMansion.Objects;
using UnityEngine;

namespace MaziesMansion
{

    [RequireComponent(typeof(Animator))]
    internal sealed class Player : MonoBehaviour
    {
        public static Player Instance { get; private set; }

        #region MovementData
        private Animator Animator;

        public float MoveSpeed = 3;
        #endregion

        public enum Location {
            F1,
            F2,
            F3
        }

        public static Location PlayerFloor;

        #region HealthData
        /// The player's current health.
        public int CurrentHealth
        {
            get => PersistentData.Instance.CurrentSanity;
            set
            {
                PersistentData.Instance.CurrentSanity = value;
                if (value <= 0)
                    Die();
            }
        }

        /// Damage Modifier
        int Damage = 20;
        #endregion

        [NonSerialized]
        public Flashlight Flashlight;
        private Interactable _interactable;
        private Footsteps _footsteps;
        private bool canTakeDamage = true;

        private void OnCollisionStay2D(Collision2D collision)
        {
            // Whenever the player is in contact with the enemy
            if (collision.collider.gameObject.tag == "Enemy")
            {
                // Check if the enemy is invulerable or not
                if (canTakeDamage)
                {
                    // Set timer and take damage
                    StartCoroutine(WaitForSeconds());
                    CurrentHealth -= Damage;
                }

            }
        }

        // Damage timer for player
        IEnumerator WaitForSeconds()
        {
            canTakeDamage = false;
            yield return new WaitForSecondsRealtime(1); // Set to 1 second
            canTakeDamage = true;
        }

        private void Awake()
        {
            if(null != Instance)
                Debug.LogError("Duplicate player object in scene", this);
            Instance = this;
            Flashlight = GetComponentInChildren<Flashlight>(includeInactive: true);
        }

        private void OnDisable()
        {
            Instance = null;
        }

        private void Start()
        {
            var save = PersistentData.Instance;
            if (save.CurrentSanity > save.MaximumSanity)
                save.CurrentSanity = save.MaximumSanity;
            Animator = GetComponent<Animator>();
            _footsteps = GetComponent<Footsteps>();

            if(null != LevelState.Instance)
            {
                LevelState.Instance.InterfaceState.OnAnyInterfaceStateChanged += value => StopAnimation();
                LevelState.Instance.InterfaceState.OnPauseMenuStateChanged += isOpen => {
                    if(isOpen)
                    {
                        save.PlayerLocation = transform.position;
                        save.CurrentSanity = CurrentHealth;
                    }
                };
            }
        }

        private void FixedUpdate()
        {

            if (LevelState.IsPaused)
            {
                if (null != _footsteps && _footsteps.Paused)
                    _footsteps.Paused = true;
                return;
            }
            else if (null != _footsteps)
                _footsteps.Paused = false;
            var xMovement = Input.GetAxisRaw("Horizontal");
            var yMovement = Input.GetAxisRaw("Vertical");

            var movementVector = new Vector2(
                x: Mathf.Abs(xMovement) < 0.5f ? 0 : xMovement * MoveSpeed * Time.deltaTime,
                y: Mathf.Abs(yMovement) < 0.5f ? 0 : yMovement * MoveSpeed * Time.deltaTime
            );
            // TODO: cap motion at magnitude 1

            // Movement animations
            Animator.SetFloat("Move X", xMovement);
            Animator.SetFloat("Move Y", yMovement);

            if (movementVector.sqrMagnitude > 0)
            {
                if(null != Flashlight)
                    Flashlight.Direction = FacingUtility.FromMotionVector(movementVector);
                transform.Translate(movementVector);
                Animator.SetBool("PlayerMoving", true);
                Animator.SetFloat("LastMoveX", Mathf.Abs(movementVector.y) > 0.5f ? 0 : movementVector.x);
                Animator.SetFloat("LastMoveY", movementVector.y);
                if (null != _footsteps)
                    _footsteps.enabled = true;
            }
            else
            {
                Animator.SetBool("PlayerMoving", false);
                if (null != _footsteps)
                    _footsteps.enabled = false;
            }

            // Interact with 'e' if interactable
            if(!LevelState.Instance.InterfaceState[InterfaceType.AnyInterface] && Input.GetKeyDown("e") && null != _interactable)
            {
                _interactable.OnPlayerInteracts?.Invoke();
            }
        }

        public void StopAnimation()
        {
            Animator.SetBool("PlayerMoving", false);
        }

        private void LateUpdate()
        {
            if (null != _interactable)
                LevelState.Instance.InteractButton.transform.position = _interactable.transform.position;
        }

        private void Die()
        {
            // revert to default save (temp)
            SaveUtility.LoadGame(PersistentData.Default);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Enemy")
            {
                CurrentHealth -= Damage;
            }

            if (other.TryGetComponent<Interactable>(out var interactable) && other.tag != "Door")
            {
                _interactable = interactable;
                LevelState.Instance.InteractButton.SetActive(true);
                LevelState.Instance.InteractButton.transform.position = _interactable.transform.position;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _interactable = null;
            LevelState.Instance.InteractButton.SetActive(false);
        }
    }
}
