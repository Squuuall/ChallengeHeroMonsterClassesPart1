using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeHeroMonsterClassesPart1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Character Hero = new Character();
            Hero.name = "Josh";
            Hero.health = 100;
            Hero.damageMax = 20;
            Hero.attackBonus = false;

            Character Monster = new Character();
            Monster.name = "Ifrit";
            Monster.health = 130;
            Monster.damageMax = 15;
            Monster.attackBonus = true;

            Dice dice = new Dice();

            if  (Hero.attackBonus)
                Monster.defend(Hero.attack(dice));
            if (Monster.attackBonus)
                Hero.defend(Monster.attack(dice));

            while (Hero.health > 0 && Monster.health > 0)
            {
                    Monster.defend(Hero.attack(dice));
                    Hero.defend(Monster.attack(dice));


                print(Hero);
                print(Monster);
            }

            displayResult(Hero, Monster);
        }

        private void displayResult(Character opponent1, Character opponent2)
        {
            if (opponent1.health <= 0 && opponent2.health <= 0)
                resultLabel.Text += string.Format("<p>Both {0} and {1} have died", opponent1.name, opponent2.name);
            else if (opponent1.health <= 0)
                resultLabel.Text += string.Format("<p>{0} defeats {1}</p>", opponent2.name, opponent1.name);
            else
                resultLabel.Text += string.Format("<p>{0} defeats {1}</p>", opponent1.name, opponent2.name);
        }

        private void print(Character character)
        {
            resultLabel.Text += string.Format("<p>Name:  {0} - Health:  {1}  - DamageMax:  {2}  - AttackBonus:  {3}</p>", character.name, character.health, character.damageMax.ToString(), character.attackBonus.ToString());
        }

    }
    class Character
    {
        public string name { get; set; }
        public int health { get; set; }
        public int damageMax { get; set; }
        public bool attackBonus { get; set; }

        public int attack(Dice dice)
        {
            //Random random = new Random();
            dice.sides = this.damageMax;

            //int damage = random.Next(this.damageMax);
            //return damage;
            return dice.roll();
        }

        public void defend(int damage)
        {
            this.health -= damage;
        }
    }

    class Dice
    {
        public int sides { get; set; }

        Random random = new Random();
        public int roll()
        {
            return random.Next(this.sides);
        }
    }
}