using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {

	public bool grounded;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float groundCheckRadius;
	//private Collider2D myCollider;

	public float moveSpeed;
	private float moveSpeedStore;
	public float speedMultiplier;
	private float speedMultiplierStore;

	public float speedIncreaseMilestone;
	public float speedIncreaseMilestoneStore;
	public float speedMilestoneCount;
	private float speedMilestoneCountStore;

	public float jumpForce;
	public float jumpTime;
	public float jumpTimeCounter;
	private bool stopJumping;
	private bool canDoubleJump;

	private Animator myAnimator;

	public GameManager theGameManager;

	private Rigidbody2D myRigidBody;



	// Use this for initialization
	void Start () {

		myRigidBody = GetComponent <Rigidbody2D> ();
		//myCollider = GetComponent<Collider2D> ();
		jumpTimeCounter = jumpTime;

		speedMilestoneCount = speedIncreaseMilestone;

		moveSpeedStore = moveSpeed;
		speedMilestoneCountStore = speedMilestoneCount;
		speedMultiplierStore = speedMultiplier;
		speedIncreaseMilestoneStore = speedIncreaseMilestone;
		stopJumping = true;

		myAnimator = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);
		grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,whatIsGround);


		if (transform.position.x > speedMilestoneCount)
		{
			speedMilestoneCount += speedIncreaseMilestone;
			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
			moveSpeed = moveSpeed * speedMultiplier;

		}

		myRigidBody.velocity = new Vector2 (moveSpeed, myRigidBody.velocity.y);
	
			
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (grounded) {
				myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);
				stopJumping = false;
				canDoubleJump = true;

			}

			if (!grounded && canDoubleJump ) {

				myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);
				stopJumping = false;
				jumpTimeCounter = jumpTime;
				canDoubleJump = false;
			}

		}

		if ( Input.GetKey (KeyCode.Space) && !stopJumping )  {
			if (jumpTimeCounter > 0) {
				myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			
			}
		}

	
		if (Input.GetKeyUp (KeyCode.Space))  {
			jumpTimeCounter = 0;
			stopJumping = true;
		}

		if (grounded) {
			jumpTimeCounter = jumpTime;
			canDoubleJump = true;
		}

		myAnimator.SetFloat ("Speed", myRigidBody.velocity.x);
		myAnimator.SetBool ("Grounded", grounded);

		//if (EventSystem.current.IsPointerOverGameObject() && EventSystem.current.currentSelectedGameObject == null) return;
		//if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
			//if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId)) return;
	}

	void OnCollisionEnter2D (Collision2D other){
			
		if (other.gameObject.tag == "killbox"){
			
			theGameManager.RestartGame();
			moveSpeed = moveSpeedStore;
			speedMilestoneCount = speedMilestoneCountStore;
			speedMultiplier = speedMultiplierStore;
			speedIncreaseMilestone = speedIncreaseMilestoneStore;

		}
	}



}