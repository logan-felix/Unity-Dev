using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTank : MonoBehaviour
{
    [SerializeField] float maxTorque = 90;
    [SerializeField] float maxForce = 1;
    [SerializeField] GameObject rocket;
    [SerializeField] GameObject barrel;
    public int ammo = 10;
    public int score = 0;
    [SerializeField] TMP_Text ammoText;
    [SerializeField] Slider healthSlider;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text scoreText2;

    float torque;
    float force;
    public bool isPaused = true;

    Rigidbody rb;
    Destructible destructible;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        destructible = GetComponent<Destructible>();
    }

    void Update()
    {
        if (!isPaused)
        {
            torque = Input.GetAxis("Horizontal") * maxTorque;
            force = Input.GetAxis("Vertical") * maxForce;

            if (Input.GetMouseButtonDown(0) && ammo > 0)
            {
                ammo--;
                Instantiate(rocket, barrel.transform.position, transform.rotation);
            }

            ammoText.text = "Ammo: " + ammo.ToString();
            scoreText.text = "Score: " + score.ToString();
            scoreText2.text = "Score: " + score.ToString();

            healthSlider.value = destructible.Health;
            if (destructible.Health <= 0)
            {
                GameManager.Instance.SetGameOver();
            }
        }
    }

    private void FixedUpdate()
    {
        //if (GameManager.Instance.state)
        rb.AddRelativeForce(Vector3.forward * force);
        rb.AddRelativeTorque(Vector3.up * torque);
    }

}
