using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoCount = 5;
    [SerializeField] GameObject pickupFx;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent(out PlayerTank component))
            {
                component.ammo += ammoCount;
                Destroy(gameObject);
                if (pickupFx != null) Instantiate(pickupFx, transform.position, Quaternion.identity);
            }
        }
    }
}
