
using UnityEngine;

public class SetAnimation : MonoBehaviour
{
  [SerializeField] private string numberCamera;
    void Start()
    {
        var _animator =  gameObject.GetComponent<Animator>();
        _animator.SetTrigger(numberCamera);
    } 
}
