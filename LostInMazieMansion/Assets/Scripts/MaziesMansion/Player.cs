using System.Collections;
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

        private Interactable _interactable;
        private Footsteps _footsteps;
        private bool canTakeDamage = true;

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.collider.gameObject.tag == "Enemy")
            {
                if (canTakeDamage)
                {
                    StartCoroutine(WaitForSeconds());
                    CurrentHealth -= Damage;
                }
               
            }
        }

        IEnumerator WaitForSeconds()
        {
            canTakeDamage = false;
            yield return new WaitForSecondsRealtime(1);
            canTakeDamage = true;
        }

        private void Start()
        {
            var save = PersistentData.Instance;
            if (save.CurrentSanity > save.MaximumSanity)
                save.CurrentSanity = save.MaximumSanity;
            Animator = GetComponent<Animator>();
            _footsteps = GetComponent<Footsteps>();
        }

        private void Update()
        {
            if(LevelState.IsPaused)
            {
                if(null != _footsteps)
                    _footsteps.Paused = true;
                return;
            } else if(null != _footsteps)
                _footsteps.Paused = false;
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
                if(null != _footsteps)
                    _footsteps.enabled = true;
            } else
            {
                Animator.SetBool("PlayerMoving", false);
                if(null != _footsteps)
                    _footsteps.enabled = false;
            }

            if (Input.GetKeyDown("e") && null != _interactable)
                _interactable.OnPlayerInteracts?.Invoke();
        }

        private void LateUpdate()
        {
            if(null != _interactable)
                LevelState.Instance.InteractButton.transform.position = _interactable.transform.position;
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
