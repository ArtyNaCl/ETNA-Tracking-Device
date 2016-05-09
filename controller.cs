using UnityEngine;
using System.Collections;

public class spotLightController : MonoBehaviour
{
	private float			Ox;
	private IEnumerator 	coroutine;
	private bool 			sens;
    private bool            timeToDie;

	public GameObject 		explosion;
	public AudioClip 		explSound;
	AudioSource 			audio;
	public 	float 			forceX;
	public	float 			forceY;
	public  float 			delay;
	public 	float 			range;
    public GameObject       cameralol;
    public GameObject       ControlPlayer;



    void Start ()
	{
		sens = true;
		Ox = transform.position.x;
		audio = GetComponent<AudioSource> ();
	}
	

	void Update ()
	{
		if (sens && transform.position.x <= (Ox + range))
			transform.Translate (forceX * Time.deltaTime, 0f, forceY * Time.deltaTime);
		else
		{
			sens = false;
			if (transform.position.x >= (Ox - range))
				transform.Translate (-forceX * Time.deltaTime, 0f, -forceY * Time.deltaTime);
			else
				sens = true;
		}
        if (timeToDie && isInRange.IsInRange == false)
            timeToDie = false;
	}

	void OnTriggerEnter (Collider collision)
 	{
		if (collision.gameObject.tag == "Player")
		{
			isInRange.IsInRange = true;
			coroutine = waitForDie (delay);
			StartCoroutine (coroutine);
		}
	 }

	void OnTriggerExit (Collider collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			isInRange.IsInRange = false;
			StopCoroutine (coroutine);
		}
	}

    void OnTriggerStay (Collider other)
    {
        if (other.gameObject.tag == "Player" && timeToDie)
        {
            audio.Play();
            Destroy(Instantiate(explosion, (transform.position - new Vector3(0, 2, 0)), transform.rotation), 2);
            Death();
        }
    }

	IEnumerator waitForDie(float delay)
	{	
		yield return new WaitForSeconds (delay);
        timeToDie = true;
	}

    void Death()
    {
        Instantiate(cameralol, new Vector3(ControlPlayer.transform.position.x, ControlPlayer.transform.position.y + 10, ControlPlayer.transform.position.z), ControlPlayer.transform.rotation);
        Destroy(ControlPlayer);
    }
}