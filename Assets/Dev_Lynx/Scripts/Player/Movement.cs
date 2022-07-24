using UnityEngine;

public class Movement : MonoBehaviour
{
        #region Variables

        [Header("Input Variable Fields - Movement")]
        [SerializeField] int playerSpeed;

        Vector3 moveDirection;

        [Header("Input Variable Fields - Jumping")]
        [SerializeField] float jumpHeight;
        [SerializeField] GameObject groundCheck;
        [SerializeField] LayerMask ground;
        
        bool jump;
        bool isGrounded;

        [Header("Player Variable Fields")]
        Rigidbody rb;

        #endregion

        #region MonoBehaviour Callbacks

        void Start() {
            rb = GetComponent<Rigidbody>();
        }

        void Update(){
            HandleAllInput();
            isGrounded = Physics.CheckSphere(groundCheck.transform.position, .2f, ground);
        }

        void FixedUpdate() {
            Move();
            if(rb.velocity.y < .75f * jumpHeight || !jump) {
                rb.velocity += Vector3.up * Physics.gravity.y * Time.fixedDeltaTime * 5f;
            }
        }

        #endregion

        #region Private Methods

        private void HandleAllInput() {
            HandleMovementInput();
            HandleJumpInput();
        }

        private void HandleMovementInput() {
                float moveX = Input.GetAxisRaw("Horizontal");
                float moveZ = Input.GetAxisRaw("Vertical");
                moveDirection = ((transform.forward * moveZ) + (transform.right * moveX)) * playerSpeed;
                moveDirection.y = rb.velocity.y;
                rb.velocity = moveDirection;
        }

        private void HandleJumpInput(){
            jump = Input.GetButtonDown("Jump");
            if(jump && isGrounded) {
                Jump();
            }
        }

        private void Move() {
            rb.velocity = moveDirection;
        }

        private void Jump(){
            
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }

        #endregion

        #region Public Methods



        #endregion
}
