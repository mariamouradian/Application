// Генеалогическое древо

public class FamilyMember
{
    int Age { get; set; }
    Gender Gender { get; set; }
    string FullName { get; set; }
    FamilyMember Mother { get; set; }
    FamilyMember Father { get; set; }

    public FamilyMember[] GetGrandMotherName()
    {
        return new FamilyMember[] {Mother.Mother, Father.Mother};
    }

    public FamilyMember[] GetGrandFatherName()
    {
        return new FamilyMember[] {Mother.Father, Father.Father };
    }
}




enum Gender {male,female}
