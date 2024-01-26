using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private float throwForce;
    [SerializeField] private Transform firePoint;
    private bool hasThrown;
    private float throwcooldown;
    private void Update()
    {
        
        if (Input.GetButtonDown("Fire1") && hasThrown == false)
        {
            Vector3 dirBall = firePoint.forward;
            GameObject currentBall = Instantiate(ball, firePoint.position, Quaternion.identity);
            currentBall.GetComponent<Rigidbody>().AddForce(dirBall.normalized * throwForce, ForceMode.Impulse);
            hasThrown = true;
        }

        throwcooldown += Time.deltaTime;
        if (throwcooldown >= 0.75f)
        {
            hasThrown = false;
            throwcooldown = 0;
        }
        
    }
}
