using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace clarotech.openehr.AOM.aom
{
    public abstract class ArchetypeConstraint : ArchetypeModelObject
    {

        private ArchetypeConstraint parent;
        private CSecondOrder<T> socParent;

        public ArchetypeConstraint Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public CSecondOrder<T> SocParent
        {
            get { return socParent; }
            set { socParent = value; }
        }

        public abstract List<PathSegment> GetPathSegments();

        public string Path
        {
            get { return PathUtil.GetPath(GetPathSegments()); }
            private set
            {
                // Setter hack for serialization, unfortunately
            }
        }

        public Archetype Archetype
        {
            get
            {
                ArchetypeConstraint constraint = Parent;
                return constraint == null ? null : constraint.Archetype;
            }
        }
    }
}
