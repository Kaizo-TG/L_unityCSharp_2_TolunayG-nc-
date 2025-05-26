using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Fracture fracture = collision.collider.GetComponent<Fracture>();
        if (fracture == null)
            fracture = collision.collider.GetComponentInParent<Fracture>();
        if (fracture == null)
            fracture = collision.collider.GetComponentInChildren<Fracture>();

        if (fracture != null && fracture.fracturedVersion != null)
        {
            GameObject fractured = Instantiate(fracture.fracturedVersion, fracture.transform.position, fracture.transform.rotation);
            fractured.transform.localScale = fracture.transform.localScale;

            Destroy(fracture.gameObject);
        }

        Destroy(gameObject); // Kugel zerstören
    }
}
