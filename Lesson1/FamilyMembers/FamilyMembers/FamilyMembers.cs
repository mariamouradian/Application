using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyMembers
{
    // Генеалогическое древо

    public class FamilyMember
    {
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string FullName { get; set; }
        public FamilyMember Mother { get; set; }
        public FamilyMember Father { get; set; }

        public FamilyMember[] GetGrandMotherName()
        {
            return new FamilyMember[] { Mother?.Mother, Father?.Mother };
        }

        public FamilyMember[] GetGrandFatherName()
        {
            return new FamilyMember[] { Mother?.Father, Father?.Father };
        }
    }

    public enum Gender { male, female }

}
