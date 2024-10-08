using System.Collections.Immutable;
using coIT.Libraries.LexOffice.DataContracts.Invoice;
using CSharpFunctionalExtensions;

namespace coIT.Lexoffice.GdiExport.Prüfregeln.Rechnung.Leistungsempfänger
{
    internal class LeistungsEmpfängerExistiert : IchPrüfe<Invoice>
    {
        private readonly IImmutableSet<string> _bekannteLeistungsempfänger;

        public LeistungsEmpfängerExistiert(IImmutableSet<string> leistungsempfänger)
        {
            _bekannteLeistungsempfänger = leistungsempfänger;
        }

        public Result Prüfen(Invoice rechnung)
        {
            var leistungsEmpfängerAufRechnung = rechnung.Address.ContactId;

            var leistungsempfängerOderNull = _bekannteLeistungsempfänger.FirstOrDefault(
                bekannterLeistungsempfänger =>
                    bekannterLeistungsempfänger == rechnung.Address.ContactId
            );

            if (leistungsempfängerOderNull is not null)
                return Result.Success();

            return Result.Failure(
                $"Mit der Leistungsempfänger ID {leistungsEmpfängerAufRechnung} konnte kein Leistungsempfänger verknüpft werden"
            );
        }
    }
}
