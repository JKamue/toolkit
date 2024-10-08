﻿using System.ComponentModel;
using coIT.Libraries.Clockodo.TimeEntries.Contracts;

namespace coIT.Lexoffice.GdiExport.Mitarbeiterliste;

internal class Mitarbeiter
{
    public int Nummer { get; set; }
    public string Name { get; set; }
    public bool Aktiv { get; set; }

    [Browsable(false)]
    public Team Team { get; set; }

    public string TeamName => Team.Name;
}
