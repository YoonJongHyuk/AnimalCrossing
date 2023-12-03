using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrigger : MonoBehaviour
{
    [Header("인벤토리")]
    public Inventory inventory;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Item")
        {
            IObjectItem clickInterface = coll.transform.gameObject.GetComponent<IObjectItem>();

            if (clickInterface != null)
            {
                Item item = clickInterface.OnTriggerItem();
                print($"{item.itemName}");
                inventory.AddItem(item);

                // 아이템을 획득한 후에는 해당 아이템 게임 오브젝트를 파괴합니다.
                Destroy(coll.gameObject);
            }
        }
    }
}
