using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrigger : MonoBehaviour
{
    [Header("�κ��丮")]
    public Inventory inventory;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Item")
        {
            IObjectItem onTriggerItem = coll.transform.gameObject.GetComponent<IObjectItem>();

            if (onTriggerItem != null)
            {
                Item item = onTriggerItem.OnTriggerItem();
                print($"{item.itemName}");
                inventory.AddItem(item);

                // �������� ȹ���� �Ŀ��� �ش� ������ ���� ������Ʈ�� �ı��մϴ�.
                Destroy(coll.gameObject);
            }
        }
    }
}
