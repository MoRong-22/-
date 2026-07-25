using UnityEngine;

public class MainCharacterController : MonoBehaviour
{
    public void EndAnimationSkillAttack1()
    {
        GetComponent<Animator>().SetBool("SkillAttack1",false);
    }
}
