
public class Player : LivingEntity
{
    void Start()
    {
        InitHealth();
    }

    protected override void OnTakeDamage()
    {
        base.OnTakeDamage();
        //TODO: Communicate new health
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        //TODO: Trigger Death animation
        gameObject.SetActive(false);

        //GameManager.Instance.GoToMenu();
    }
}
