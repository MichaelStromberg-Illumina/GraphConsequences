using GraphConsequences.SequenceOntologyNodes;

namespace GraphConsequences
{
    public class ConsequenceGraphFactory
    {
        public static IOntologyNode Build()
        {
            var stopLost            = new StopLostVariant();
            var spliceSite          = new SpliceSiteVariant();
            var frameshift          = new FrameshiftVariant();
            var nonCodingTranscript = new NonCodingTranscriptVariant();

            var nonSynonymous     = new NonSynonymousVariant(new IOntologyNode[] { stopLost });
            var featureElongation = new FeatureElongation(new IOntologyNode[] { stopLost });
            var terminatorCodon   = new TerminatorCodonVariant(new IOntologyNode[] { stopLost });

            var inframe         = new InframeVariant(new IOntologyNode[] { nonSynonymous });
            var proteinAltering = new ProteinAlteringVariant(new IOntologyNode[] { inframe, frameshift });        
            var codingSequence  = new CodingSequenceVariant(new IOntologyNode[] { proteinAltering, terminatorCodon });

            var intron           = new IntronVariant(new IOntologyNode[] { spliceSite });
            var exon             = new ExonVariant(new IOntologyNode[] { codingSequence });
            var codingTranscript = new CodingTranscriptVariant(new IOntologyNode[] { codingSequence });

            return new TranscriptVariant(new IOntologyNode[] { featureElongation, exon, intron, codingTranscript, nonCodingTranscript });
        }
    }
}
