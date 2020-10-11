using NodeEditorFramework.Standard;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(NPCController))]
public class NPC : MonoBehaviour
{
    //scriptable NPC Data
    public NPCData npcData;
    public NPCController npcController;
    public Vector3 DetectCenter;
    public float DetectRadius;
    [SerializeField]
    private QuestController npcQuests;
    [SerializeField]
    private bool hasQuest;
    [SerializeField]
    private GameObject meetingPlayer;
    // Start is called before the first frame update
    void Start()
    {
        initNPC();
    }

    // Update is called once per frame
    void Update()
    {
        //抓取玩家
        meetingPlayer = npcController.catchPlayer(DetectCenter, DetectRadius);
        var playerQuestController = meetingPlayer?.GetComponent<PlayerQuestController>();
        if (hasQuest && playerQuestController)
            StartCoroutine(talkAndAssignQuest(playerQuestController)); //如有任務就分配

    }
    private void initNPC() 
    {
        npcData?.SetNPCID(System.Guid.NewGuid().ToString());
        npcQuests = GetComponentInChildren<QuestController>();
        npcController = GetComponentInChildren<NPCController>();
        hasQuest = npcQuests ? true : false;
    }
    private IEnumerator talkAndAssignQuest(PlayerQuestController playerQuestController)
    {
        //wait until finish talk
        //searching player quest set list to check there's no equal quest
        if (!playerQuestController.searchingEqualQuestSet(npcQuests)) 
        {
            playerQuestController.acceptTheQuests(npcQuests);
        }
        
        yield return null;
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(DetectCenter, DetectRadius);
    }
}
