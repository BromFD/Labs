namespace Labs;

public abstract class TaskManager // Класс управления заданиями
{
    private LabMethods? methods;

    public abstract void Call(int part, int task); // Обязательная к реализации функция вызова заданий
}