using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    public bool isNormalSize = false;
     private void OnTriggerEnter(Collider other){
        isNormalSize=true;
    } 
}
