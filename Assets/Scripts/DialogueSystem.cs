using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text txtName;
    public Text txtSentance;

    Queue<string> sentances = new Queue<string>();

    public Animator anim;

    public GameObject txtBtn;

    public void Begin(Dialogue info)
    {
        anim.SetBool("isOpen", true);
        sentances.Clear();

        txtName.text = info.name;

        foreach(var sentance in info.sentances)
        {
            sentances.Enqueue(sentance);
        }

        Next();
    }

    public void Next()
    {
        if(sentances.Count == 0)
        {
            End();
            return;
        }

        //txtSentance.text = sentances.Dequeue();
        txtSentance.text = string.Empty;
        StopAllCoroutines();
        StartCoroutine(TypeSentance(sentances.Dequeue()));
    }

    IEnumerator TypeSentance(string sentance)
    {
        foreach(var letter in sentance)
        {
            txtSentance.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void End()
    {
        anim.SetBool("isOpen", false);
        txtSentance.text = string.Empty;

        txtBtn.SetActive(true);
    }
}
