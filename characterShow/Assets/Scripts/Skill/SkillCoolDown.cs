using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCoolDown : MonoBehaviour
{
    public KeyCode ShortCut;
    public Image skillImage;
    public Image DarkMask;
    public Text CoolDownCountText;

    [SerializeField] private Skill skill;
    [SerializeField] private ISkillContext skillContext;

    private Image myButtonImage;
    private AudioSource skillAudioSource;
    private float coolDownDuration;
    private float nextReadyTime; //下次冷卻結束時間
    private float coolDownTimeLeft; //用作倒數的時間數

    public void initialize(string skillID , KeyCode keycode)
    {
        skill = SkillManager.instance.GetSkill(skillID);
        skillContext = skill.GetSkillContext();
        ShortCut = keycode;
        myButtonImage = GetComponent<Image>();
        skillAudioSource = GetComponent<AudioSource>() ?? gameObject.AddComponent<AudioSource>();
        myButtonImage.sprite = skill?.SkillSprite;
        DarkMask.sprite = skill?.SkillSprite;
        coolDownDuration = skill.SkillCoolDown;
        skillReady();

    }
    private void Update()
    {
        bool coolDownComplete = (Time.time > nextReadyTime);
        if (coolDownComplete)
        {
            skillReady();
            if (Input.GetKeyDown(ShortCut) && skill != null)
            {
                shortCutTrigger();
            }
        }
        else
        {
            coolDown();
        }
    }
    private void skillReady() 
    {
        CoolDownCountText.enabled = false;
        DarkMask.enabled = false;
        skillContext?.PrepareSkill();
        
    }
    private void coolDown()
    {
        coolDownTimeLeft -= Time.deltaTime;
        float roundedCD = Mathf.Round(coolDownTimeLeft); //類四捨五入(.5時有時進位，有時則無)
        CoolDownCountText.text = roundedCD.ToString();
        DarkMask.fillAmount = (coolDownTimeLeft / coolDownDuration); //調整透明度
    }
    private void shortCutTrigger() 
    {
        nextReadyTime = coolDownDuration + Time.time; //紀錄冷卻結束的時間
        coolDownTimeLeft = coolDownDuration; //填滿倒數的時間數
        DarkMask.enabled = true;
        CoolDownCountText.enabled = true;

        /* skillAudioSource.clip = skill?.SkillSound;
         skillAudioSource.Play();*/
        StartCoroutine(skillContext.StartSkill());
    }
}
