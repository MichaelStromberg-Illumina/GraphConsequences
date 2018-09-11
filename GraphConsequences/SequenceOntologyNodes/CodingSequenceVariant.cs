using System;
using VariantAnnotation.Interface.AnnotatedPositions;

namespace GraphConsequences.SequenceOntologyNodes
{
    // A sequence variant that changes the coding sequence.
    // SO:0001580
    public class CodingSequenceVariant : IOntologyNode
    {
        public bool IsActive { get; private set; }
        private int _activeParentCount;
        public bool AreAllParentsActive => _activeParentCount == 2;
        public ConsequenceTag Consequence { get; } = ConsequenceTag.coding_sequence_variant;
        public IOntologyNode[] Children { get; }
        
        public CodingSequenceVariant(IOntologyNode[] children) => Children = children;

        public void Evaluate(INodeData data)
        {
            if (data.CoveredCdsStart != -1 && data.CoveredCdsEnd != -1) IsActive = true;
        }

        public void Register(ConsequenceTag parentConsequence)
        {
            if (parentConsequence == ConsequenceTag.exon_variant ||
                parentConsequence == ConsequenceTag.coding_transcript_variant) _activeParentCount++;
            Console.WriteLine($"-- CodingSequenceVariant.Register: parent: {parentConsequence}, count: {_activeParentCount}");
        }
    }
}
