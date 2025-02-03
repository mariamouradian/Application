using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyMembers
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            FamilyMember GrandFatherOne = new FamilyMember()
            {
                FullName = "Иванов Иван Иванович",
                Age = 50,
                Gender = Gender.male,
            };
            FamilyMember GrandFatherTwo = new FamilyMember()
            {
                FullName = "Иванов Петр Петрович",
                Age = 51,
                Gender = Gender.male,
            };
            FamilyMember GrandMotherOne = new FamilyMember()
            {
                FullName = "Петрова Мария Дмитриевна",
                Age = 60,
                Gender = Gender.female,
            };
            FamilyMember GrandMotherTwo = new FamilyMember()
            {
                FullName = "Смирнова Екатерина Ивановна",
                Age = 48,
                Gender = Gender.female,
            };
            FamilyMember Mother = new FamilyMember()
            {
                FullName = "Петрова Вера Ивановна",
                Age = 30,
                Gender = Gender.female,
                Mother = GrandMotherTwo,
                Father = GrandFatherTwo,
            };
            FamilyMember Father = new FamilyMember()
            {
                FullName = "Петров Кирилл Иванович",
                Age = 35,
                Gender = Gender.male,
                Mother = GrandMotherOne,
                Father = GrandFatherOne
            };
            FamilyMember Son = new FamilyMember()
            {
                FullName = "Петров Аркадий Кириллович",
                Age = 16,
                Gender = Gender.male,
                //Mother = Mother,
                Father = Father
            };

            var GrandMothers = Son.GetGrandMotherName();
            Console.WriteLine(GrandMothers[0]?.FullName);
            Console.WriteLine(GrandMothers[1]?.FullName);

        }
    }
}
