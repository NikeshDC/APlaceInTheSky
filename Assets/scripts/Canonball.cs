using UnityEngine;
using UnityEngine.Audio;

public class Canonball : MonoBehaviour
{
    public GameObject explosion;

    public float explosionForce = 30f;
    public float explosionRange =  5f;

    public AudioSource impactAudio;

    public void OnCollisionEnter(Collision collision)
    {
        impactAudio.Play();
        if (collision.collider.tag == "target")
        {
           //on_impact_explode();
        }
    }

    public void on_impact_explode()
    {
        GameObject explosionObj = Instantiate(explosion, transform.position, Quaternion.identity);
        Collider[] collidingObjects = Physics.OverlapSphere(transform.position, explosionRange);
        Rigidbody collidingObjectsRb;
        foreach (Collider collidingObject in collidingObjects)
        {
            collidingObjectsRb = collidingObject.gameObject.GetComponent<Rigidbody>();
            if (collidingObjectsRb != null)
                collidingObjectsRb.AddExplosionForce(explosionForce, transform.position, explosionRange);
        }
        Destroy(explosionObj, 5f);
        Destroy(this.gameObject);
    }
}
