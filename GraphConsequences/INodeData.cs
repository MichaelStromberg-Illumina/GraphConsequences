using VariantAnnotation.Interface.AnnotatedPositions;
using VariantAnnotation.Interface.Positions;

namespace GraphConsequences
{
    public interface INodeData
    {
        IVariant Variant { get; }
        ITranscript Transcript { get; }
        IMappedPosition MappedPosition { get; }
        int CoveredCdsStart { get; }
        int CoveredCdsEnd { get; }
        int CoveredProteinStart { get; }
        int CoveredProteinEnd { get; }
        string ReferenceAminoAcids { get; }
        string AlternateAminoAcids { get; }

        void Assign(IVariant variant, ITranscript transcript, IMappedPosition mappedPosition, int cdsStart, int cdsEnd,
            string referenceAminoAcids, string alternateAminoAcids, int coveredProteinStart, int coveredProteinEnd);
    }
}
