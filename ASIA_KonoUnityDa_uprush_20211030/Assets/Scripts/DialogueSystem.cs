using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// ��ܨt��
/// �N�ݭn��X����r�Q�Υ��r�ĪG�e�{
/// </summary>
public class DialogueSystem : MonoBehaviour
{
    [Header("��ܶ��j"), Range(0, 1)]
    public float interval = 0.3f;
    [Header("�e����ܨt��")]
    public GameObject goDialogue;
    [Header("��ܤ��e")]
    public Text textContent;
    [Header("��ܧ����ϥ�")]
    public GameObject goTip;
    [Header("��ܨt��")]
    public KeyCode keyDialongue = KeyCode.Mouse0;



    private void Start()
    {
        //StartCoroutine(TypeEffect());
    }

    /// <summary>
    /// ���r�ĪG
    /// </summary>
    /// <param name="contents">�Q�n�X�{��ܨt�Ϊ���ܤ��e�A�ݨϥΦr��}�C</param>
    /// <returns></returns>

    private IEnumerator TypeEffect(string[] contents)
    {
        //�󴫦W�٧ֱ��� Ctrl + R R
        //���ե�
        //string test1 = "���o�A�A�n��";
        //string test2 = "�ĤG�q���";
        //string[] contents = { test1, test2 };
        
        goDialogue.SetActive(true);

        for (int j = 0; j < contents.Length; j++)
        {  
            textContent.text = "";
            goTip.SetActive(false);

            for (int i = 0; i < contents[j].Length; i++)
           {
            textContent.text += contents[j][i];
            yield return new WaitForSeconds(interval);
           } 

          goTip.SetActive(true);

            while (!Input.GetKeyDown(keyDialongue))
            {
                yield return null;
            }

        }

        goDialogue.SetActive(false);
    }

    /// <summary>
    /// �}�l���
    /// </summary>
    public void StartDialogue(string[] contents)
    {
        StartCoroutine(TypeEffect(contents));
    }

    /// <summary>
    /// ������
    /// </summary>
    public void StoptDialogue()
    {
        StopAllCoroutines();
        goDialogue.SetActive(false);

    }


}
