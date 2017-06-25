using UnityEngine;
using System.Collections;

public class Controles : MonoBehaviour {

	public float thrustSpeed;
	public float turnSpeed;
	private Rigidbody2D body;
	private bool onThruster;
	private bool onBackThruster;
	private bool onRight;
	private bool onLeft;
	private float lastRotation;
	public float maxTurnSpeed;
	public float maxThrustSpeed;
	public ParticleSystem particaleThrust;
	public int particaleIntence;
	

	// Use this for initialization
	void Start () 
	{
		lastRotation = 0;
		body = GetComponent<Rigidbody2D>();
		onLeft = false;
		onRight = false;
		onThruster = false;
		onBackThruster = false;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if(Input.GetButton("Thruster"))
		{
			onThruster = true;
		}
		else
		{
			onThruster = false;
		}
		
		if(Input.GetButton("BackThruster"))
		{
			onBackThruster = true;
		}
		else
		{
			onBackThruster = false;
		}
		
		if(Input.GetButton("TurnRight"))
		{
			onRight = true;
		}
		else
		{
			onRight = false;
		}
		
		if(Input.GetButton("TurnLeft"))
		{
			onLeft = true;
		}
		else
		{
			onLeft = false;
		}
		
	}
	
	void FixedUpdate()
	{
		if(onThruster && Mathf.Sqrt(Mathf.Pow(Mathf.Abs(body.velocity.y),2) + Mathf.Pow(Mathf.Abs(body.velocity.x),2)) <= maxThrustSpeed)
		{
			body.AddForce(transform.up * thrustSpeed);
			particaleThrust.Emit(particaleIntence);
		}
		else
		{
			body.AddForce(transform.up * (thrustSpeed/2));
		}
		
		if(onBackThruster && Mathf.Sqrt(Mathf.Pow(Mathf.Abs(body.velocity.y),2) + Mathf.Pow(Mathf.Abs(body.velocity.x),2)) <= maxThrustSpeed)
		{
			body.AddForce(transform.up* -1 * thrustSpeed);
		}
		else
		{
			body.AddForce(transform.up* -1 * (thrustSpeed/2));
		}
		
		if(onRight && Mathf.Abs(body.rotation - lastRotation) <= maxTurnSpeed)
		{
			body.AddTorque(turnSpeed * -1);
		}
		
		if(onLeft && Mathf.Abs(body.rotation - lastRotation) <= maxTurnSpeed)
		{
			body.AddTorque(turnSpeed);
		}
		print(Mathf.Sqrt(Mathf.Pow(Mathf.Abs(body.velocity.y),2) + Mathf.Pow(Mathf.Abs(body.velocity.x),2)));
		
		lastRotation = body.rotation;
	}
	
}
