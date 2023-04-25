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
    public float range;     // ���� ���� �Ÿ�
    public float accuracy;  // ���� ��Ȯ��
    public float fireRate;  // ���� �ӵ�
    public float reloadTime;// ������ �ӵ�

    public int damage;      // ���� ���ݷ�
    public int area;        //���߹���
    public int reloadBulletCount;   // ���� ������ ����
    public int currentBulletCount;  // ���� �� ���� źâ�� �����ִ� �Ѿ��� ����.
    public int maxBulletCount;      // �Ѿ��� �ִ� �� ������ ������ �� �ִ���. 
    public int carryBulletCount;    // ���� �� �ٱ����� �����ϰ� �ִ� �Ѿ��� �� ����.

    public float retroActionForce;  // �ݵ� ����
    public float retroActionFineSightForce; // �����ؽ� �ݵ� ����

    public Vector3 findSightOriginPos;  // �����ؽ� ���� ���� ��ġ
    public string rootName;
    public string bullitname;
    public Animator anim;   // ���� �ִϸ��̼��� ����� �ִϸ����� ������Ʈ
    public ParticleSystem muzzleFlash;
    public AudioClip fire_Sound;
    public Transform muzzleTransform;
}
