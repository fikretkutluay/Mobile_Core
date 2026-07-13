# 📱 Mobile Core Framework for Unity

Bu proje, Unity ile geliştirilen mobil oyunlar (Hybrid-Casual, Puzzle, Pixel Flow, Merge vb.) için tasarlanmış; modüler, performansı yüksek ve tamamen **SOLID** prensiplerine uygun bir **Çekirdek (Core) Mimari** kütüphanesidir.

Oyun mekaniklerine odaklanmadan önce projenin ihtiyaç duyacağı tüm temel sistemleri (Haberleşme, UI, Performans, Kayıt, Uzamsal Matris) izole ve jenerik bir şekilde sunar.

## ⚙️ Temel Sistemler ve Özellikler

### 1. Event-Driven Haberleşme Ağı (Observer Pattern)
Sınıfların birbirine referans vermesini (Spaghetti Code) engellemek için `Action` tabanlı merkezi bir olay yöneticisi.
* **Kullanım:** UI, Ekonomi veya Oyun Yöneticisi birbirini bilmeden `GameEvents` üzerinden haberleşir.
* `GameEvents.OnLevelCompleted += ShowWinPanel;`

### 2. Jenerik Grid ve Matris Sistemi
Özellikle Puzzle ve Board oyunları için matematiksel uzay ve hücre yönetimi.
* **Kullanım:** `GridManager<T>` ile istenilen veri tipinde X ve Y koordinatlı hücresel yapılar oluşturulur, dünya pozisyonları anında hesaplanır.

### 3. Jenerik Object Pooler (Performans Katmanı)
Mobil cihazlarda Garbage Collector (GC) darboğazını engellemek için tasarlandı.
* **Auto-Expand (Otomatik Genişleme):** Havuz boşaldığında hata vermek yerine, kuyruktaki objelerin `activeSelf` durumunu kontrol ederek kendini otomatik ve güvenli bir şekilde genişletir.
* `ObjectPooler.Instance.SpawnFromPool("Bullet", pos, rot);`

### 4. Data-Driven Mimari (Scriptable Objects)
Oyun verilerini (Item özellikleri, Level konfigürasyonları) koda gömmek yerine Inspector üzerinden yönetilebilir `ItemData` ve `LevelData` varlıkları (Assets) olarak tutar.

### 5. Soyutlanmış JSON Save Sistemi
Cihazın yerel depolamasına güvenli kayıt yapan, interface tabanlı generic yapı.
* **Kullanım:** `ISerializer` arayüzü sayesinde ileride kayıt sistemi (Binary, Cloud vb.) değişse bile oyunun geri kalan kodları bu değişimden etkilenmez. 
* `saveSystem.Save<PlayerData>(data, "PlayerSave");`

### 6. Responsive UI ve Panel Yöneticisi (DOTween Entegrasyonlu)
Cihaz çözünürlüklerinden bağımsız ve animasyonlu arayüz sistemi.
* **Kullanım:** Tüm paneller `BasePanel` soyut sınıfından miras alır. `UIManager`, Event sistemini dinleyerek (örn. Level Failed olduğunda) ilgili panelleri pürüzsüz `Fade In/Out` efektleriyle ekrana getirir.

---

## 🛠️ Kurulum ve Gereksinimler

1. Projeyi Unity (Önerilen: 2022 LTS ve üzeri) ile açın.
2. Projenizde animasyonlar ve UI geçişleri için **DOTween (Demigiant)** paketinin kurulu olduğundan emin olun.
3. Kendi oyununuza başlarken `Assets/_Scripts` klasörü altındaki bu çekirdek yapıyı koruyun ve kendi oyun mekaniklerinizi (Örn: PlayerController, LevelManager) bu sistemlerin üzerine inşa edin.

## 📂 Klasör Hiyerarşisi

```text
Assets/
├── _Scripts/
│   ├── Data/        # ScriptableObject şablonları (ItemData, LevelData)
│   ├── Events/      # Merkezi haberleşme sistemi (GameEvents)
│   ├── Grid/        # Jenerik ızgara mantığı (GridManager)
│   ├── Pool/        # Obje havuzu ve tanımlayıcılar (ObjectPooler, Pool)
│   ├── Save/        # ISerializer ve JsonSaveSystem
│   └── UI/          # UIManager ve BasePanel mimarisi
