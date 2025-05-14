using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace clarotech.openehr.AOM.utils
{
    internal class PathSegment
    {
        private static readonly Func<IEnumerable<string>, string> expressionJoiner = items => string.Join(",", items.Where(item => item != null));

        private static readonly Regex archetypeRefPattern = new Regex(@"(.*::)?.*-.*-.*\..*\.v.*");

        private static readonly Regex nodeIdPattern = new Regex(@"id(\.?\d)+|at(\.?\d)+");

        private String nodeName;
        private String nodeId;
        private String archetypeRef = null;
        private int? index;

        public PathSegment()
        { }

        public PathSegment(String nodeName, int index) : this(nodeName, null, index)
        { }


        public PathSegment(String nodeName, String nodeId) : this(nodeName, nodeId, null)
        { }

        public PathSegment(String nodeName) : this(nodeName, null, null)
        { }

        public PathSegment(String nodeName, String nodeId, int? index)
        {
            this.nodeName = nodeName;
            this.nodeId = nodeId;
            this.index = index;
        }

        public string NodeId
        {
            get { return nodeId; }
            set { nodeId = value; }
        }
        public int? Index
        {
            get { return index; }
            set { index = value; }
        }

        public String ArchetypeRef
        {
            get { return archetypeRef; }
            set { archetypeRef = value; }
        }

        public bool HasIdCode()
        {
            return nodeId != null && nodeIdPattern.IsMatch(nodeId);
        }

        public bool HasNumberIndex()
        {
            return index != null;
        }

        public bool HasArchetypeRef()
        {
            return nodeId != null && archetypeRefPattern.IsMatch(nodeId);
        }

        public override string ToString()
        {
            if (HasExpressions())
            {
                return "/" + nodeName + "[" + JoinExpressions(nodeId, index) + "]";
            }
            else
            {
                return "/" + nodeName;
            }
        }

        public bool HasExpressions()
        {
            return nodeId != null || index != null;
        }

        private string JoinExpressions(string nodeId, int? index)
        {
            var expressions = new List<string>();

            if (nodeId != null)
                expressions.Add(nodeId);

            if (index != null)
                expressions.Add(index.ToString());

            return string.Join(",", expressions);
        }
    }
}
