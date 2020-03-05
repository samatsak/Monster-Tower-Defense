using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform target;
	public string enemyTag = "Enemy";

	public float speed = 70f;

	public int damage = 50;

	public float explosionRadius = 0f;
	public GameObject impactEffect;

	public void Seek (Transform _target)
	{
		target = _target;
	}

	// Update is called once per frame
	void Update () {

		if (target == null)
		{
			Destroy(gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame)
		{
			HitTarget();
			return;
		}

		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
		transform.LookAt(target);

	}

	void HitTarget ()
	{
		GameObject effectIns = (GameObject)PhotonNetwork.Instantiate (impactEffect.name, transform.position, transform.rotation, 0);
		Destroy(effectIns, 5f);

		if (explosionRadius > 0f)
		{
			Explode();
		} else
		{
			Damage(target);
		}

		Destroy(gameObject);
	}

	void Explode ()
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
		Debug.Log (colliders.Length);
		foreach (Collider collider in colliders)
		{
//			Debug.Log (collider.transform.GetComponent<Enemy>().worth);
//			Debug.Log (collider.tag);
//			Debug.Log (explosionRadius);
			if (collider.tag == enemyTag)
			{
//				Debug.Log ("worth"+collider.transform.GetComponent<Enemy>().worth);
				Damage(collider.transform);
			}
		}
	}

	void Damage (Transform enemy)
	{
		Enemy e = enemy.GetComponent<Enemy>();
		Debug.Log ("worth:"+e.worth);
		if (e != null)
		{
			Debug.Log ("damage:"+damage);
			e.TakeDamage(damage);
		}
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, explosionRadius);
	}
}
