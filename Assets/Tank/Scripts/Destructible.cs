using UnityEngine;

public class Destructible : MonoBehaviour, IDamagable
{
    [SerializeField] float health = 20;
    [SerializeField] int scorePoints = 100;
    [SerializeField] GameObject destroyFx;

    bool destroyed = false;

    public float Health { get { return health; } set { health = (value < 0) ? 0 : value; } }

    public void ApplyDamage(float damage)
    {
        if (destroyed) return;

        health -= damage;
        if (health <= 0)
        {
            destroyed = true;
            if (destroyFx != null) Instantiate(destroyFx, transform.position, Quaternion.identity);

            PlayerTank playerTank = FindFirstObjectByType(typeof(PlayerTank)) as PlayerTank;
            if (playerTank != null)
            {
                playerTank.score += scorePoints;
            }

            if (!gameObject.TryGetComponent(out PlayerTank component))
            {
                Destroy(gameObject);
            }
        }
    }
}
