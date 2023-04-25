using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordActive : WeaponActive
{
    Collider collider;
    List<EnemyObj> hitEnemys;
    private void Awake()
    {
    }
    private void Start()
    {
        hitEnemys = new List<EnemyObj>();
    }
    private void OnEnable()
    {
        collider = GetComponent<BoxCollider>();
    }
    private void Update()
    {
        GunFireRateCalc();
    }
    void GunFireRateCalc()
    {
        if (currentFireRate > 0)
            currentFireRate -= Time.deltaTime;
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
    private void Fire()
    {
        currentFireRate = rifle.fireRate;
        hitEnemys.Clear();
        Shoot();
    }
    private void Shoot()
    {
        StartCoroutine("activeCollider");
        //foreach(var data in enemyBounds)
        //{
        //    if(bounds.Intersects(data))
        //    {
        //        WM.EnemyHit(data);
        //    }
        //}
    }
    void HitCal(EnemyObj enemy)
    {

    }
    IEnumerator activeCollider()
    {
        while (currentFireRate > 0)
        {
            foreach (var Edata in HitManager.instance.enemyColliders)
            {
                if (collider.bounds.Intersects(Edata.collider.bounds))
                {
                    if (!hitEnemys.Contains(Edata))
                    {
                        Edata.EnemyHit(rifle.damage);
                        hitEnemys.Add(Edata);
                    }
                }
            }
            yield return null;
        }
        yield break;
    }
}
