using System;
using VariantAnnotation.Interface.AnnotatedPositions;

namespace GraphConsequences.SequenceOntologyNodes
{
    // A sequence variant whereby at least one of the bases in the terminator codon is changed.
    // SO:0001590
    public class TerminatorCodonVariant : IOntologyNode
    {
        public bool IsActive { get; private set; }
        public bool AreAllParentsActive { get; private set; }
        public ConsequenceTag Consequence { get; } = ConsequenceTag.terminator_codon_variant;
        public IOntologyNode[] Children { get; }

        public TerminatorCodonVariant(IOntologyNode[] children) => Children = children;

        public void Evaluate(INodeData data)
        {
            int terminatorCodonPos = data.Transcript.Translation.CodingRegion.Length - 3;
            if (data.MappedPosition.CdnaStart >= terminatorCodonPos) IsActive = true;
        }

        public void Register(ConsequenceTag parentConsequence)
        {
            if (parentConsequence == ConsequenceTag.coding_sequence_variant) AreAllParentsActive = true;
        }
    }
}
