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
	private Quaternion lastRotation;
	public float maxTurnSpeed;
	

	// Use this for initialization
	void Start () 
	{
		
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
		if(onThruster)
		{
			body.AddForce(transform.up * thrustSpeed);
		}
		
		if(onBackThruster)
		{
			body.AddForce(transform.up* -1 * thrustSpeed);
		}
		
		if(onRight)
		{
			if(transform.rotation.z - lastRotation[2] <= maxTurnSpeed)
			{
				body.AddTorque(turnSpeed * -1);
			}
		}
		
		if(onLeft)
		{
			if(transform.rotation.z - lastRotation[2] <= maxTurnSpeed)
			{
				body.AddTorque(turnSpeed);
			}
		}
		print(transform.rotation.z);
		
		lastRotation = transform.rotation;
	}
	
}
