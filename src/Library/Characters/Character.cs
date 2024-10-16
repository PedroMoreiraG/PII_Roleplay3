namespace Ucu.Poo.RoleplayGame;

public abstract class Character
{
    public string Name { get; set; }
    public int health = 100;
    private List<IItem> items = new List<IItem>();

    public Character(string Name)
    {
        this.Name = Name;
    }
    
    public int Health
    {
        get
        {
            return this.health;
        }
        private set
        {
            this.health = value < 0 ? 0 : value;
        }
    }
    
    public virtual int AttackValue
    {
        get
        {
            int value = 0;
            foreach (IItem item in this.items)
            {
                if (item is IAttackItem)
                {
                    value += (item as IAttackItem).AttackValue;
                }
            }
            return value;
        }
    }

    public virtual int DefenseValue
    {
        get
        {
            int value = 0;
            foreach (IItem item in this.items)
            {
                if (item is IDefenseItem)
                {
                    value += (item as IDefenseItem).DefenseValue;
                }
            }
            return value;
        }
    }
    
    public virtual void AddItem(IItem item)
    { 
        this.items.Add(item);
    }

    public virtual void RemoveItem(IItem item)
    {
        this.items.Remove(item);
    }

    public virtual void Cure()
    {
        this.Health = 100;
    }

    public virtual void ReceiveAttack(int power)
    {
        if (this.DefenseValue < power)
        {
            this.Health -= power - this.DefenseValue;
        }
    }
    
}
