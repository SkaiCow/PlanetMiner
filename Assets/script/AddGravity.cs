using UnityEngine;
using System.Collections;

public class AddGravity : MonoBehaviour {
	
	public float pullRadius = 2;
    public float pullForce = 1;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		
		foreach(Collider2D collider in Physics2D.OverlapCircleAll(transform.position, pullRadius))
		{
			if(collider.gameObject.tag != "Player")
			{
				return;
			}
			else
			{
				Vector2 forceDirection = transform.position - collider.transform.position;
				collider.gameObject.GetComponent<Rigidbody2D>().AddForce(forceDirection.normalized * pullForce * Time.fixedDeltaTime);
			}
		}
		
	}
	void OnDrawGizmosSelected() 
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, pullRadius);
	}
}
