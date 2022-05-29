namespace Data.Objects
{
    public abstract class RuleCard : Card
    {
        // TODO: add rule as class variable to evaluate, if rule has been violated or fullfilled. Create new Rule-Object
        protected int _points;

        protected abstract bool AssertRuleViolation();

        public int Points
        {
            get { return _points; }
        }
    }
}