using System;
using VariantAnnotation.Interface.AnnotatedPositions;

namespace GraphConsequences.SequenceOntologyNodes
{
    // A non-synonymous variant is an inframe, protein altering variant, resulting in a codon change.
    // SO:0001992
    public class NonSynonymousVariant : IOntologyNode
    {
        public bool IsActive { get; }
        public bool AreAllParentsActive { get; }
        public ConsequenceTag Consequence { get; } = ConsequenceTag.nonsynonymous_variant;
        public IOntologyNode[] Children { get; }

        public NonSynonymousVariant(IOntologyNode[] children) => Children = children;

        public void Evaluate(INodeData data)
        {
            throw new NotImplementedException();
        }

        public void Register(ConsequenceTag parentConsequence)
        {
            throw new NotImplementedException();
        }
    }
}
