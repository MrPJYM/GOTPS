using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class interRay : MonoBehaviour
{
    public delegate void Do();
    Do @do = null;
    public RectTransform AimUI;
    public List<ItemBox> box;
    public Image Fimage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(AimUI.position);//Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0f));
        if (Physics.Raycast(ray, out hit, 200f))//currentWeaponActive.rifle.range))
        {
            if (hit.distance <= 10f && hit.collider.gameObject.tag.Equals("ItemBox"))
            {
                foreach (var data in box)
                {
                    if (data.gameObject.Equals(hit.collider.gameObject))
                    {
                        Fimage.gameObject.SetActive(true);
                        @do = data.OpneBox;
                    }
                }
            }
            else
            {
                foreach (var data in box)
                {
                    Fimage.gameObject.SetActive(false);
                    @do = null;
                }
            }
        }
        else
        {
            foreach (var data in box)
            {
                Fimage.gameObject.SetActive(false);
                @do = null;
            }
        }
        if (PlayerInput.instance.IsInterativeF)
        {
            if (@do != null)
                @do();
        }
    }
    private void LateUpdate()
    {
    }
}
