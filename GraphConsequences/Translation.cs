using VariantAnnotation.Interface.AnnotatedPositions;
using VariantAnnotation.Interface.IO;

namespace GraphConsequences
{
    public sealed class Translation : ITranslation
    {
        public ICodingRegion CodingRegion { get; }
        public ICompactId ProteinId { get; }
        public string PeptideSeq { get; }

        public Translation(ICodingRegion codingRegion, CompactId proteinId, string peptideSeq)
        {
            CodingRegion = codingRegion;
            ProteinId    = proteinId;
            PeptideSeq   = peptideSeq;
        }

        public void Write(IExtendedBinaryWriter writer, int peptideIndex)
        {
            CodingRegion.Write(writer);
            ProteinId.Write(writer);
            writer.WriteOpt(peptideIndex);
        }
    }
}