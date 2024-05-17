public class GameObject
{
    public bool IsInteractable { get; set; }

    public GameObject(bool isInteractable)
    {
        IsInteractable = isInteractable;
    }

    // Методы для взаимодействия можно добавить здесь
}
