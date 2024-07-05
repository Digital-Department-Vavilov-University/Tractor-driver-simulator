using UnityEngine;

public class IntercativeController : MonoBehaviour
{
    [SerializeField] private Transform rudder;
    [SerializeField] private float speedRotateRudder = 1f;

    [SerializeField] private Transform[] wipers;
    [SerializeField] private Light[] lights;

    float angleRudderZ = 0f;
    float lateAngleRudderZ = 0f;
    Animator animator;
    private void Start()
    {
        angleRudderZ = rudder.rotation.z;
        animator = GetComponent<Animator>();
    }
    //установить все элементы интерактивные в стартовое положение
    private void Init()
    {
        //определить предварительно угол текущий вычитанием!!!//

        //выворачиваем руль (переписать на эйлера)
        rudder.Rotate(0f, 0f, 0f);

        //выключаем свет
        foreach (var light in lights)
        {
            light.enabled = false;
        }
    }

    bool enabledWiper = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (angleRudderZ > -180f) angleRudderZ -= speedRotateRudder;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (angleRudderZ < 180f) angleRudderZ += speedRotateRudder;
        }
        else
        {
            if (angleRudderZ > 0f) angleRudderZ -= speedRotateRudder;
            else if (angleRudderZ < 0f) angleRudderZ += speedRotateRudder;
            else angleRudderZ = 0f;
        }

        rudder.Rotate(0f, 0f, angleRudderZ - lateAngleRudderZ);

        if (Input.GetKeyUp(KeyCode.E)) 
        {
            foreach (var light in lights)
            {
                light.enabled = !light.enabled;
            }
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            enabledWiper = !enabledWiper;
            animator.SetBool("Wipper", enabledWiper);
        }
        
        lateAngleRudderZ = angleRudderZ;
        //отдельное условие для включение анимации дворников
    }
}
