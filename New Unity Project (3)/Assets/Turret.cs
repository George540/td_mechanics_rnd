using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	public Transform target;
	public float range = 15f;
	public Transform rotator;
	public Transform rotator2;
	public Vector3 rotation2;
	public float turnSpeed = 10f;
	public float moveX;
	public float min;
	public float max;


	// Use this for initialization
	void Start () {
		InvokeRepeating("UpdateTarget", 0f, 0.1f);
		rotation2 = rotator2.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null) {
			return;
		}

		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation1 = Quaternion.Lerp(rotator.rotation, lookRotation, Time.deltaTime*turnSpeed).eulerAngles;
		rotator.rotation = Quaternion.Euler(0f, rotation1.y, 0f);
		rotator2.rotation = Quaternion.Euler(rotation2.x, rotation2.y, 0f);
		moveX = rotator2.rotation.eulerAngles.x;
		moveX = Mathf.Clamp(moveX, 116, 360);

		if(rotation2.x < min) {rotation2.x = min;}
		else {rotation2 = Quaternion.Lerp(rotator2.rotation, lookRotation, Time.deltaTime*turnSpeed).eulerAngles;}
		if(rotation2.x > max) {rotation2.x = max;}
		else {rotation2 = Quaternion.Lerp(rotator2.rotation, lookRotation, Time.deltaTime*turnSpeed).eulerAngles;}
	}

	void UpdateTarget() {
		GameObject enemy = GameObject.FindGameObjectWithTag("enemyTag");
		float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

		if (enemy != null && distanceToEnemy <= range) {
			target = enemy.transform;
		}
		else {
			target = null;
		}

	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}
