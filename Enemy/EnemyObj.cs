using UnityEngine;

public class EnemyObj : MonoBehaviour
{
    public Collider collider;
    public float currentHP;
    public void EnemyHit(Bullit bullit)
    {
        currentHP -= bullit.RA.rifle.damage;
        bullit.returnThis();
        Debug.Log("Hit");
    }
    public void EnemyHit(float num)
    {
        currentHP -= num;
        Debug.Log("Hit = " + num.ToString());
    }
    private void Awake()
    {
        collider = gameObject.GetComponent<BoxCollider>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
