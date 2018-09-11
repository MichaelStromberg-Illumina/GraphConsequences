using System;
using VariantAnnotation.Interface.AnnotatedPositions;

namespace GraphConsequences.SequenceOntologyNodes
{
    // A sequence variant where at least one base of the terminator codon (stop) is 
    // changed, resulting in an elongated transcript.
    // SO:0001578
    public class StopLostVariant : IOntologyNode
    {
        public bool IsActive { get; }
        private int _activeParentCount;
        public bool AreAllParentsActive => _activeParentCount == 3;
        public ConsequenceTag Consequence { get; } = ConsequenceTag.stop_lost;
        public IOntologyNode[] Children { get; } = null;

        public void Evaluate(INodeData data)
        {
            throw new NotImplementedException();
        }

        public void Register(ConsequenceTag parentConsequence)
        {
            if (parentConsequence == ConsequenceTag.nonsynonymous_variant ||
                parentConsequence == ConsequenceTag.feature_elongation ||
                parentConsequence == ConsequenceTag.terminator_codon_variant) _activeParentCount++;
            Console.WriteLine($"-- StopLostVariant.Register: parent: {parentConsequence}, count: {_activeParentCount}");
        }
    }
}
