using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyMembers
{
    public enum Gender { male, female }
    // Генеалогическое древо

    public class FamilyMember
    {
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string FullName { get; set; }
        public FamilyMember Mother { get; set; }
        public FamilyMember Father { get; set; }
        public FamilyMember Spouse { get; set; }
        

        public FamilyMember[] GetGrandMotherName()
        {
            return new FamilyMember[] { Mother?.Mother, Father?.Mother };
        }

        public FamilyMember[] GetGrandFatherName()
        {
            return new FamilyMember[] { Mother?.Father, Father?.Father };
        }
        public string GetSpouseName()
        {
            return Spouse != null ? Spouse.FullName : "Нет супруга";
        }

        public void PrintFamilyTree(string indent = "")
        {
            Console.WriteLine($"{indent}{FullName} ({Age})");
            if (Spouse != null)
            {
                Console.WriteLine($"{indent}  ├── Супруг(а): {Spouse.FullName} ({Spouse.Age})");
            }
            if (Father != null)
            {
                Console.WriteLine($"{indent}  ├── Отец: {Father.FullName} ({Father.Age})");
            }
            if (Mother != null)
            {
                Console.WriteLine($"{indent}  ├── Мать: {Mother.FullName} ({Mother.Age})");
            }
        }
    }


}
