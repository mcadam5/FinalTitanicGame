using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public class Civilian : Npc, ISpeak
    {
        public override int Id { get; set; }
        public override string Description { get; set; }
        public List<string> Messages { get; set;}

        public string Speak()
        {
            if (this.Messages !=null)
            {
                return GetMessage();
            }
            else
            {
                return $"My name is {base.Name} and I am a {base.Ethnicity}";
            }
        }

        private string GetMessage()
        {
            Random r = new Random();
            int messageIndex = r.Next(0, Messages.Count());
            return Messages[messageIndex];
        }
    }
}
