using System.Collections.Generic;
public class Antivirus : Tool {
    public Antivirus(string name, int hp, int attack, int defense) : base(name, true, hp, attack, defense) {
        Actions.Add(new Action("Байтовый взрыв", ActionType.Attack, 80));
        Actions.Add(new Action("Крипто-клинок", ActionType.Attack, 60));
        Actions.Add(new Action("Щит кибернетика", ActionType.DefenseBoost, 20));
      }
}
