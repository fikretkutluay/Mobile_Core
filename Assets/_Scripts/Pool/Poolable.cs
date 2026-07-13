using UnityEngine;

public class PoolableObject : MonoBehaviour
{
    public string poolTag = "Bullet";
    public float lifetime = 2f;

    private void OnEnable()
    {
        // Mermi sahnede aktif edildiği an 2 saniyelik geri sayımı başlat
        Invoke(nameof(Deactivate), lifetime);
    }

    private void OnDisable()
    {
        // Mermi 2 saniye dolmadan başka bir sebeple (çarpışma vb.) 
        // havuza dönerse, zamanlayıcıyı iptal et ki hata çıkmasın
        CancelInvoke(nameof(Deactivate));
    }

    private void Deactivate()
    {
        ObjectPooler.Instance.ReturnToPool(poolTag, gameObject);
    }
}