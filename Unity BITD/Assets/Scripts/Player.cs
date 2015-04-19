﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public GameObject player;
	public GameObject bump;
    public GameObject arrow;
	// Use this for initialization
	void Start () {
		//начальное направление игрока - ось OX!	
	}
	
	// Update is called once per frame
	void Update () {

		//движение игрока за мышкой
		var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		var angle = Vector2.Angle(Vector2.right, mousePosition - transform.position);
		transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < mousePosition.y ? angle : -angle);

		//создание стрелки по нажатию на левую кнопку мыши

	    if (Input.GetMouseButtonDown(0)) {
	    }

	    if (Input.GetMouseButtonUp(0)) {
			var cloneBump = (GameObject) Instantiate (bump);
			Vector3 bumpDir = mousePosition - player.transform.position;
			cloneBump.transform.rotation = Quaternion.LookRotation (Vector3.forward, bumpDir);
<<<<<<< HEAD
            cloneBump.rigidbody2D.AddRelativeForce(new Vector2(0f, 50f));
			}
=======
			cloneBump.rigidbody2D.AddRelativeForce (new Vector2 (0f, 500f));

				}
>>>>>>> origin/master
	}
}
