namespace clarotech.openehr.AOM.aom
{
    public class CSecondOrder<T> : ArchetypeModelObject where T : ArchetypeConstraint
    {
        private List<T> members = new List<T>();

        public T GetMember(int i)
        {
            return members[i];
        }

        public List<T> Members
        {
            get { return members; }
            set
            {
                members = value ?? new List<T>();
                foreach (T member in members)
                {
                    SetThisAsSocParent(member);
                }
            }
        }

        private void SetThisAsSocParent(T member)
        {
            if (member != null)
            {
                member.SocParent = this;
            }
        }

        public void AddMember(T member)
        {
            members.Add(member);
            SetThisAsSocParent(member);
        }
    }
}
