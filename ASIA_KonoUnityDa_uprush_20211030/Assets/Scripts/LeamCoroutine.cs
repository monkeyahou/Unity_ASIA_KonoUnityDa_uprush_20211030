using UnityEngine;
using System.Collections; //�ޥ� �t��.���X �]�t��P�{��


/// <summary>
/// �{�Ѩ�P�{��
/// </summary>
public class LeamCoroutine : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Test());              // �Ұʨ�P�{��(��P�{��())
        StartCoroutine(TestWithLoop());
    }

    // �w�q��P�{��
    // �Ǧ^���� IEnumerator
    private IEnumerator Test()
    {
        print("�o�O�Ĥ@�q��r�T��~");
        yield return new WaitForSeconds(1);
        print("�o�O�ĤG�q��r�T��~");
        yield return new WaitForSeconds(3);
        print("�S���F�T����...");
    }

    private IEnumerator TestWithLoop()
    {

        for (int i = 0; i < 10; i++)
        {
            print("�Ʀr :" + i);
            yield return new WaitForSeconds(0.5f);
        }
    }
}