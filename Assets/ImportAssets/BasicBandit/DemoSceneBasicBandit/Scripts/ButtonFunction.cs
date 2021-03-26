using UnityEngine;
using System.Collections;

public class ButtonFunction : MonoBehaviour {

	public Animator animator;

    private float m_TurnInputValue;
    private float m_TurnSpeed = 100;

    // Use this for initialization
    void Start () {
		animator = GetComponent<Animator>();
	}


    private void Update()
    {
        m_TurnInputValue = Input.GetAxis("Horizontal");
    }

    // Update is called once per frame
    void FixedUpdate () {
        Rigidbody rigidbody;
        rigidbody = GetComponent<Rigidbody>();

        if (Input.GetAxis("Vertical") > 0)
        {
            float zAxis = Input.GetAxis("Vertical");

            rigidbody.AddForce(0f, 0f, zAxis * 10);

            Walk();
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        if (Input.GetAxis("Horizontal") != 0)
        {

            float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

            rigidbody.MoveRotation(rigidbody.rotation * turnRotation);
        }
    }

	public void Idle ()
	{
		animator = GetComponent<Animator>();
		animator.SetBool ("Walk", false);
		animator.SetBool ("SprintJump", false);
		animator.SetBool ("SprintSlide", false);
	}

	public void Walk ()
	{
		animator = GetComponent<Animator>();
		animator.SetBool ("Walk", true);
		animator.SetBool ("SprintJump", false);
		animator.SetBool ("SprintSlide", false);
	}

	public void SprintJump()
	{
		animator = GetComponent<Animator>();
		animator.SetBool ("Walk", false);
		animator.SetBool ("SprintJump", true);
		animator.SetBool ("SprintSlide", false);
	}

	public void SprintSlide()
	{
		animator = GetComponent<Animator>();
		animator.SetBool ("Walk", false);
		animator.SetBool ("SprintJump", false);
		animator.SetBool ("SprintSlide", true);
	}
}
