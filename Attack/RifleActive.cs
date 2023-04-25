using UnityEngine;
public class RifleActive : WeaponActive
{
    public Transform muzzleTrasform;
    public Animator animator;
    public LayerMask layer;
    private void Awake()
    {

    }
    private void Start()
    {
        muzzleTrasform = rifle.muzzleTransform;
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        GunFireRateCalc();
    }
    public override void GetOut()
    {
        gameObject.transform.SetParent(null);

        WM = null;
    }
    void GunFireRateCalc()
    {
        if (currentFireRate > 0)
            currentFireRate -= Time.deltaTime;
    }
    public void RifleChange(WeaponData changeRifle)
    {
        rifle = changeRifle;
    }
    public override bool TryFire()
    {
        if (currentFireRate <= 0)
        {
            Fire();
            return true;
        }
        else
            return false;
    }

    private void Fire()  // 발사를 위한 과정
    {
        currentFireRate = rifle.fireRate;
        animator.SetTrigger("Shoot");
        Shoot();
    }
    void RayHitFrame()
    {
        RaycastHit hit;
        if (Physics.Raycast(rifle.muzzleTransform.position, WM.Aimpos.position - transform.position, out hit, layer))
        {
            hit.collider.gameObject.BroadcastMessage("EnemyHit", rifle.damage);
        }
    }
    private void Shoot()  // 실제 발사 되는 과정
    {
        RayHitFrame();
        //currentrifle.muzzleFlash.Play();
        //Bullit bullit=null;
        //do
        //{
        //    bullit = BulltObjpool.GetObject(rifle.bullitname);
        //} while (bullit == null);
        //HitManager.instance.bulletColliders.Add(bullit);
        //bullit.RA = this;
        //GameObject obj = bullit.gameObject;
        //obj.transform.localScale = new Vector3(10, 10, 10);
        //obj.transform.position = rifle.muzzleTransform.position;
        //obj.transform.LookAt(WM.Aimpos.position);
    }
}
