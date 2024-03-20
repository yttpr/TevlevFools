// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.NerdRoom
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using System.Linq;
using Tools;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public static class NerdRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Zensuke";

    private static string Files => "Zensuke_CH";

    private static Character chara => Zensuke.Sale;

    private static int Zone => 2;

    private static bool Left => true;

    private static bool Center => false;

    public static Color32 Color => new Color32((byte) 143, (byte) 86, (byte) 59, byte.MaxValue);

    private static string roomName => NerdRoom.Name + "Room";

    private static string convoName => NerdRoom.Name + "Convo";

    private static string encounterName => NerdRoom.Name + "Encounter";

    private static Sprite Talk => NerdRoom.chara.frontSprite;

    private static Sprite Portal => NerdRoom.chara.unlockedSprite;

    private static string Audio => NerdRoom.chara.dialogueSound;

    private static int ID => (int) NerdRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) NerdRoom.ID, NerdRoom.Portal);
      NerdRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + NerdRoom.Name + "Room.prefab");
      NerdRoom.Room = NerdRoom.Base.AddComponent<NPCRoomHandler>();
      NerdRoom.Room._npcSelectable = (BaseRoomItem) ((Component) ((Component) NerdRoom.Room).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      NerdRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) NerdRoom.Room._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) NerdRoom.Room._npcSelectable._renderers[0]).material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = NerdRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Tevlev." + NerdRoom.Name + ".TryHire";
      NerdRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = NerdRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = NerdRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = NerdRoom.roomName;
      instance2._freeFool = NerdRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) NerdRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) NerdRoom.ID
      };
      NerdRoom.Free = instance2;
      NerdRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = NerdRoom.Audio,
        portrait = NerdRoom.Talk,
        bundleTextColor = (NerdRoom.Color)
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = NerdRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = NerdRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = NerdRoom.bundle;
      instance3.portraitLooksLeft = NerdRoom.Left;
      instance3.portraitLooksCenter = NerdRoom.Center;
      NerdRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + NerdRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + NerdRoom.roomName, (BaseRoomHandler) NerdRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + NerdRoom.roomName] = (BaseRoomHandler) NerdRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(NerdRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(NerdRoom.convoName, NerdRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[NerdRoom.convoName] = NerdRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(NerdRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(NerdRoom.encounterName, NerdRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[NerdRoom.encounterName] = NerdRoom.Free;
      Backrooms.AddPool(NerdRoom.encounterName, 0);
      Backrooms.AddPool(NerdRoom.encounterName, 1);
      Backrooms.AddPool(NerdRoom.encounterName, 2);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(NerdRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(NerdRoom.speaker.speakerName, NerdRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[NerdRoom.speaker.speakerName] = NerdRoom.speaker;
    }
  }
}
