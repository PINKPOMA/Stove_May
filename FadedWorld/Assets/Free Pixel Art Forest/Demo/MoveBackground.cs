using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
	public Player player;
	public float speed;
	private float x;
	public float PontoDeDestino; // 일정 좌표로 이동했을시 그좌표로
	public float PontoOriginal; // 이미지 갈이
	
	void Update () {
		
		x = transform.position.x;
		x += speed * Time.deltaTime;
		transform.position = new Vector3 (x, transform.position.y, transform.position.z);



		if (x <= PontoDeDestino){

			Debug.Log ("hhhh");
			x = PontoOriginal;
			transform.position = new Vector3 (x, transform.position.y, transform.position.z);
		}


	}
}
