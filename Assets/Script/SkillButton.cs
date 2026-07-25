using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    private Animator ani;
    private void Awake()
    {
        GameObject mainCharacter = GameObject.FindWithTag("MainCharacter");
        ani= mainCharacter.GetComponent<Animator>();
    }
    public void Onclike()
    {
        ani.SetBool("SkillAttack1", true);
    }
}
