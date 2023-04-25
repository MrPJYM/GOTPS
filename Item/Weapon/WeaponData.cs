using UnityEngine;

public enum Weapon_Type
{
    AR,
    GUN,
    SWORD,
    SHOTGUN
};
public class WeaponData
{
    public string gunName;
    public Weapon_Type type;
    public float range;     // 총의 사정 거리
    public float accuracy;  // 총의 정확도
    public float fireRate;  // 연사 속도
    public float reloadTime;// 재장전 속도

    public int damage;      // 총의 공격력
    public int area;        //폭발범위
    public int reloadBulletCount;   // 총의 재장전 개수
    public int currentBulletCount;  // 현재 총 안의 탄창에 남아있는 총알의 개수.
    public int maxBulletCount;      // 총알을 최대 몇 개까지 소유할 수 있는지. 
    public int carryBulletCount;    // 현재 총 바깥에서 소유하고 있는 총알의 총 개수.

    public float retroActionForce;  // 반동 세기
    public float retroActionFineSightForce; // 정조준시 반동 세기

    public Vector3 findSightOriginPos;  // 정조준시 총이 향할 위치
    public string rootName;
    public string bullitname;
    public Animator anim;   // 총의 애니메이션을 재생할 애니메이터 컴포넌트
    public ParticleSystem muzzleFlash;
    public AudioClip fire_Sound;
    public Transform muzzleTransform;
}
