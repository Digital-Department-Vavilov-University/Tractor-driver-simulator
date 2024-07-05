using UnityEngine;

public class Connectting : MonoBehaviour
{
    [SerializeField] HingeJoint joint;
    [SerializeField] Rigidbody rb;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("вилка"))
        {
            joint.connectedBody = other.GetComponentInParent<Rigidbody>();
            rb.AddForce(transform.up * 500f, ForceMode.Impulse); //надо фиксить
        }
    }
}
