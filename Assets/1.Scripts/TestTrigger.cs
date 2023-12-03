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
            IObjectItem clickInterface = coll.transform.gameObject.GetComponent<IObjectItem>();

            if (clickInterface != null)
            {
                Item item = clickInterface.OnTriggerItem();
                print($"{item.itemName}");
                inventory.AddItem(item);

                // �������� ȹ���� �Ŀ��� �ش� ������ ���� ������Ʈ�� �ı��մϴ�.
                Destroy(coll.gameObject);
            }
        }
    }
}
