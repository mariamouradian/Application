//Доработайте приложение генеалогического дерева таким образом,
//чтобы программа выводила на экран близких родственников (жену/мужа).
//Продумайте способ более красивого вывода
//с использованием горизонтальных и вертикальных черточек.




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
                Gender = Gender.male
            };
            FamilyMember GrandFatherTwo = new FamilyMember()
            {
                FullName = "Иванов Петр Петрович",
                Age = 51,
                Gender = Gender.male
            };
            FamilyMember GrandMotherOne = new FamilyMember()
            {
                FullName = "Петрова Мария Дмитриевна",
                Age = 60,
                Gender = Gender.female,
                Spouse = GrandFatherOne
            };
            FamilyMember GrandMotherTwo = new FamilyMember()
            {
                FullName = "Смирнова Екатерина Ивановна",
                Age = 48,
                Gender = Gender.female,
                Spouse = GrandFatherTwo
            };

            GrandFatherOne.Spouse = GrandMotherOne;
            GrandMotherOne.Spouse = GrandFatherOne;

            GrandFatherTwo.Spouse = GrandMotherTwo;
            GrandMotherTwo.Spouse = GrandFatherTwo;

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
                Father = GrandFatherOne,
                Spouse = Mother
            };

            Mother.Spouse = Father;
            Father.Spouse = Mother;

            FamilyMember Son = new FamilyMember()
            {
                FullName = "Петров Аркадий Кириллович",
                Age = 16,
                Gender = Gender.male,
                Mother = Mother,
                Father = Father
            };

            var GrandMothers = Son.GetGrandMotherName();
            var GrandFathers = Son.GetGrandFatherName();

            //Console.WriteLine(GrandMothers[0]?.FullName);
            //Console.WriteLine(GrandMothers[1]?.FullName);
            //Console.WriteLine(GrandFathers[0]?.FullName);

            Console.WriteLine("Семейное древо:");
            Son.PrintFamilyTree();
            Console.WriteLine();
            Father.PrintFamilyTree();
            Console.WriteLine();
            Mother.PrintFamilyTree();

            //Console.WriteLine($"Супруг(а) отца: {Father.GetSpouseName()}");
            //Console.WriteLine($"Супруг(а) деда 1: {GrandFatherOne.GetSpouseName()}");
            //Console.WriteLine($"Супруг(а) деда 2: {GrandFatherTwo.GetSpouseName()}");


        }
    }
}
