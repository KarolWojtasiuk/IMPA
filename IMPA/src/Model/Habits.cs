namespace IMPA
{
    public class Habits
    {
        public HabitFrequency Cigarettes;
        public HabitFrequency Alcohol;
        public HabitFrequency Drugs;
        public HabitFrequency Coffee;
    }

    public enum HabitFrequency
    {
        Unkown,
        Never,
        Occasionally,
        Always
    }
}
