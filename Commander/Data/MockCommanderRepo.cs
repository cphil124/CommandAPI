using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil Water", Platform = "Kettle & Pan" },
                new Command { Id = 2, HowTo = "Cut Bread", Line = "Get a knife", Platform = "Knife and Chopping Board"},
                new Command { Id = 4, HowTo = "Boil an egg", Line = "Boil Water", Platform = "Kettle & Pan" }
            };

            return commands;
        }

        public Command GetCommandByID(int id)
        {
            var commands = new List<Command>
            {
                new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil Water", Platform = "Kettle & Pan" },
                new Command { Id = 2, HowTo = "Cut Bread", Line = "Get a knife", Platform = "Knife and Chopping Board"},
                new Command { Id = 4, HowTo = "Boil an egg", Line = "Boil Water", Platform = "Kettle & Pan" }
            };
            foreach (Command item in commands)
            {
                if (id == item.Id)
                {
                    return item;
                }
            }
            return new Command { Id = 99, HowTo = "Blank", Line = "Empty", Platform = "None" };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}