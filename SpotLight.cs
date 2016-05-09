using UnityEngine;
using System.Collections;

public class SpotLight : MonoBehaviour
{	
	private Vector3 distance;
	private Quaternion QTO;
	private Light spotlight;
	private float radius;
	private Color color0;
	private Color color1;

	public GameObject zone;
	public float duration;

	void Start ()
	{
		spotlight = GetComponent<Light> ();
		color0 = Color.white;
		color1 = Color.red;
	}
		
	void Update ()
	{
		if (isInRange.IsInRange == true) {
			float t = Mathf.PingPong (Time.time, duration) / duration;
			spotlight.color = Color.Lerp (color0, color1, t);
		} else {
			spotlight.color = color0;
		}
		distance = transform.position - zone.transform.position;
		QTO = Quaternion.LookRotation (distance * -1);
		transform.rotation = QTO;
	}
}
 