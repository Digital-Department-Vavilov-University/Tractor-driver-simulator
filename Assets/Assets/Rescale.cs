using UnityEngine;
using System.Collections.Generic;

public class Rescale : MonoBehaviour
{
    public List<CheckCollision> allCollison = new List<CheckCollision>();

    void Start()
    {
        transform.position+= new Vector3(0f,-172f,0f);
    }
    private void Update() {
       foreach (var col in allCollison)
       {
        if(!col.isNormalSize){
            Vector3 add = new Vector3(1f,1f, 1f);
            transform.localScale+=add;
        }
    }
  }
}