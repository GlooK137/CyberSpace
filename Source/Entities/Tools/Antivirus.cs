using System.Collections.Generic;
public class Antivirus : Tool {
    public Antivirus(string name, int hp, int attack, int defense) : base(name, true, hp, attack, defense) {
        Actions.Add(new Action("Байтовый взрыв", ActionType.Attack, 20));
        Actions.Add(new Action("Крипто-клинок", ActionType.Attack, 10));
        Actions.Add(new Action("Щит кибернетика", ActionType.DefenseBoost, 15));
      }
}
