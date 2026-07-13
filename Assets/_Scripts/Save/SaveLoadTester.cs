using UnityEngine;

public class SaveLoadTester : MonoBehaviour
{
    private JsonSaveSystem saveSystem = new JsonSaveSystem();
    private PlayerData playerData = new PlayerData();

    void Update()
    {
        // SPACE: Kaydet
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerData.playerGold += 100; // Her basışta 100 altın ekle
            playerData.playerLevel++;
            saveSystem.Save(playerData, "PlayerSave");
        }

        // ENTER: Yükle
        if (Input.GetKeyDown(KeyCode.Return))
        {
            saveSystem.Load("PlayerSave", out playerData);
            
            if (playerData != null)
            {
                Debug.Log($"Yüklenen Veri -> Altın: {playerData.playerGold}, Level: {playerData.playerLevel}");
            }
        }
    }
}