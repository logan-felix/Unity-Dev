using UnityEngine;

public class WinArea : MonoBehaviour
{

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out PlayerTank component))
        {
            component.GetComponent<GameManager>().SetWin();
        }
    }
}
