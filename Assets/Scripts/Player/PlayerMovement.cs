using Environment;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player {
    public class PlayerMovement : MonoBehaviour {
        [SerializeField]
        private Animator animator = null;

        public float RotateSpeed = 10f;

        [Header("Input")]
        [SerializeField]
        private InputActionReference moveAction = null;
        [SerializeField]
        private InputActionReference interactAction = null;

        [Header("Movement")]
        [SerializeField]
        private float movementSpeed = 10f;
        [Header("Interaction")]
        [SerializeField]
        private float interactionRange = 5f;

        public GameObject InteractablePrompt;

        public bool InteractableInRange;

        private Vector2 movementInput = Vector2.zero;

        private void Awake() {
            if(!animator) {
                Debug.LogError("Animator not set");
                return;
            }

            if(!moveAction || !interactAction) {
                Debug.LogError("Input actions not set");
                return;
            }

            moveAction.action.performed += OnMove;
            moveAction.action.canceled += OnMove;

            interactAction.action.performed += OnInteract;
        }

        private void OnMove(InputAction.CallbackContext context) {
            movementInput = context.ReadValue<Vector2>();
            animator.SetBool("bIsMoving", movementInput != Vector2.zero);
        }

        private void CheckInteractable () {
            Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, interactionRange);
            IInteractable interactable = hit.collider?.gameObject.GetComponentInParent<IInteractable>();
            if (interactable != null) {
                InteractableInRange = true;
            }
            else {
                InteractableInRange = false;
            }

            if (InteractableInRange && !InteractablePrompt.activeSelf) {
                InteractablePrompt.SetActive(true);
            }
            else if (!InteractableInRange && InteractablePrompt.activeSelf) {
                InteractablePrompt.SetActive(false);
            }
        }

        private void OnInteract(InputAction.CallbackContext context) {
            Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, interactionRange);
            IInteractable interactable = hit.collider?.gameObject.GetComponentInParent<IInteractable>();
            if(interactable != null) {
                interactable.OnInteract();
            }
        }

        private void Update() {
            transform.Translate(new Vector3(0, 0, movementInput.y * movementSpeed * Time.deltaTime));
            transform.Rotate(new Vector3(0, movementInput.x * RotateSpeed * Time.deltaTime, 0));
            CheckInteractable();
        }


        private void OnEnable() {
            moveAction.action.Enable();
            interactAction.action.Enable();
        }

        private void OnDisable() {
            moveAction.action.performed -= OnMove;
            moveAction.action.canceled -= OnMove;

            interactAction.action.performed -= OnInteract;

            moveAction.action.Disable();
            interactAction.action.Disable();
        }

        public void DisableInput() {
            moveAction.action.Disable();
            interactAction.action.Disable();
        }

        public void EnableInput() {
            moveAction.action.Enable();
            interactAction.action.Enable();
        }
    }
}
