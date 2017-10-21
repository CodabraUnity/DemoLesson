using UnityEngine;

public class MovingStoneScript : MonoBehaviour {
    [Header("Движение камня по осям:"), LabelOverride("Ось X")]
    public float x = 0;

    [LabelOverride("Ось Y")]
    public float y = 0;

    [LabelOverride("Ось Z")]
    public float z = 0;

    [Space(15), LabelOverride("Скорость камня")]
    public float speed = 0;

    private Vector3 direction;

    private float remainDistance;

    private void Setup()
    {
        direction = new Vector3(x, y, z);
        remainDistance = direction.sqrMagnitude;
    }

    private void SetupTransform()
    {
        Transform child = gameObject.transform.GetChild(0);

        Vector3 scale = child.localScale;
        scale.x *= transform.localScale.x;
        scale.y *= transform.localScale.y;
        scale.z *= transform.localScale.z;

        child.localScale = scale;
        transform.localScale = Vector3.one;

        Vector3 temp = transform.eulerAngles;
        transform.eulerAngles = Vector3.zero;
        child.eulerAngles = temp;
    }

    private void Start()
    {
        Setup();
        SetupTransform();        
    }

    private void Update()
    {
        transform.Translate(direction * speed * 0.02f);

        remainDistance -= direction.sqrMagnitude * speed * 0.02f;
        if (remainDistance <= 0)
        {
            remainDistance = direction.sqrMagnitude;
            direction = -direction;
        }
    }
}