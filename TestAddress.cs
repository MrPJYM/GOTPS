using UnityEngine;
public class TestAddress : MonoBehaviour
{
    //[SerializeField] Image mIMG;
    //AsyncOperationHandle Handle;

    //public void _ClickLoad()
    //{
    //    Addressables.LoadAssetAsync<Sprite>("Picture").Completed +=
    //        (AsyncOperationHandle<Sprite> Obj) =>
    //        {
    //            Handle = Obj;
    //            mIMG.sprite = Obj.Result;
    //        };
    //}
    //public void _ClickUnload()
    //{
    //    Addressables.Release(Handle);//�ÿ��� ���ϸ� �ݵ�� ������ ������
    //    mIMG.sprite = null;
    //}
    //[SerializeField] GameObject Obj;
    //[SerializeField] AssetReference Ref;
    //private void Start()
    //{
    //    Ref.InstantiateAsync(Obj.transform);
    //}
    //[SerializeField] AssetReference Ref;
    //GameObject tmpobj;
    //private void Start()
    //{
    //    Ref.InstantiateAsync(new Vector3(0, -1, 0), Quaternion.identity).Completed +=
    //        (AsyncOperationHandle<GameObject> obj) =>
    //        {
    //            tmpobj = obj.Result;
    //            Invoke("releaseDestory", 3f);//3�ʵ� ���� 
    //        };
    //}

    //void releaseDestory()
    //{
    //    Ref.ReleaseInstance(tmpobj);
    //}
    public Rigidbody body;
    private void Start()
    {
        body.velocity = new Vector3(5, 0, 0);
    }
}
