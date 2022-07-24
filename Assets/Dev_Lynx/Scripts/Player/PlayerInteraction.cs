using UnityEngine;
using TMPro;


public class PlayerInteraction : MonoBehaviour
{
        #region Variables

        [Header("Player Variable Fields - Interactions")]
        [SerializeField] float interactionDistance;
        [SerializeField] Camera cam;

        public TMP_Text interactionText;
        

        #endregion

        #region MonoBehaviour Callbacks

        void Start() {
            //cam = GetComponent<Camera>();
        }

        void Update() {
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));
            RaycastHit hit;

            bool successfulHit = false;

            if(Physics.Raycast(ray, out hit, interactionDistance)) {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if(interactable != null) {
                    HandleInteraction(interactable);
                    interactionText.text = interactable.GetInteractDescription();
                    successfulHit = true;
                }
            }

            if(!successfulHit) {
                interactionText.text = "";
            }
        }

        #endregion

        #region Private Methods

        private void HandleInteraction(Interactable interactable) {
            KeyCode interactKey = KeyCode.F;

            switch(interactable.interactionType) {
                case Interactable.InteractionType.Click:
                if(Input.GetKeyDown(interactKey)) {
                    interactable.Interact();
                }
                break;
                case Interactable.InteractionType.Hold:
                if(Input.GetKey(interactKey)) {
                    interactable.Interact();
                }
                break;

                default:
                Debug.Log("Unsupported type of interaction found");
                break;
            }
        }

        #endregion

        #region Public Methods



        #endregion
}
