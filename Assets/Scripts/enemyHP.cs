using UnityEngine;
using UnityEngine.UI;

public class enemyHP : MonoBehaviour
{
	public int startingHealth = 100;
	public int currentHealth;
	public float sinkSpeed = 2.5f;
	public int scoreValue = 10;
	public AudioClip deathClip;
	public AudioClip hit;
	public GameObject healthPack;

	ParticleSystem hitParticles;
	CapsuleCollider capsuleCollider;
	bool isDead;
	bool isSinking;
	Animator animator;
	
	
	void Awake ()
	{
		capsuleCollider = GetComponent <CapsuleCollider> ();
		currentHealth = startingHealth;
		hitParticles = GetComponentInChildren <ParticleSystem> ();
		animator = GetComponent<Animator> ();
	}
	
	
	void Update ()
	{
		if(isSinking)
		{
			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
		}
	}
	
	
	public void TakeDamage (int amount, Vector3 hitPoint)
	{
		if(isDead)
			return;
		
		
		GetComponent<AudioSource>().PlayOneShot(hit);
		currentHealth -= amount;

		hitParticles.transform.position = hitPoint;






		hitParticles.Play();
		hitParticles.enableEmission = true;


		Debug.Log (hitParticles.isPlaying);



		if(currentHealth <= 0)
		{
			Death ();
		}
	}
	
	
	void Death ()
	{
		isDead = true;
		StartSinking ();
		capsuleCollider.isTrigger = true;
		animator.Play ("death", -1, 0f);
		GetComponent<AudioSource>().PlayOneShot(deathClip);

		if (healthPack != null) {
			float x = transform.position.x;
			float y = transform.position.y + 1.5f;
			float z = transform.position.z;

			transform.position = new Vector3(x,y,z);

			Instantiate(healthPack, transform.position, transform.rotation);
		}
	}
	
	
	public void StartSinking ()
	{
		GetComponent <NavMeshAgent> ().enabled = false;
		GetComponent <Rigidbody> ().isKinematic = true;
		//isSinking = true;
		changeScore.score += scoreValue;
		Debug.Log (this.tag);
		if (this.tag == "Infector") {
			Destroy (this.GetComponentInChildren<SkinnedMeshRenderer>(),0.2f);
		}
		Destroy (gameObject, 1f);
	}
}
