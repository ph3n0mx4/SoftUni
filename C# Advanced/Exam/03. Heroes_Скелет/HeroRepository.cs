using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            data = new List<Hero>();
        }

        public int Count => this.data.Count;

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public void Remove(string name)
        {
            var hero = this.data.Find(x => x.Name == name);
            this.data.Remove(hero);
        }

        public Hero GetHeroWithHighestStrength()
        {
            var maxStrengthItem = data.GroupBy(x => x.Item).OrderByDescending(y => y.Select(s => s.Item.Strength).Max()).FirstOrDefault().Key;

            var hero = data.First(x => x.Item.Strength == maxStrengthItem.Strength);
            return hero;
        }

        public Hero GetHeroWithHighestAbility()
        {
            var maxAbilityItem = data.GroupBy(x => x.Item).OrderByDescending(y => y.Select(s => s.Item.Ability).Max()).FirstOrDefault().Key;

            var hero = data.First(x => x.Item.Ability == maxAbilityItem.Ability);
            return hero;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            var maxIntelligenceItem= data.GroupBy(x => x.Item).OrderByDescending(y => y.Select(s => s.Item.Intelligence).Max()).FirstOrDefault().Key;

            var hero = data.First(x => x.Item.Intelligence == maxIntelligenceItem.Intelligence);
            return hero;
        }

        public override string ToString()
        {
            string output = string.Empty;

            foreach (var hero in data)
            {
                output = string.Concat(output, hero);
                output = string.Concat(output, Environment.NewLine);
            }
            return output; 
        }
    }
}
