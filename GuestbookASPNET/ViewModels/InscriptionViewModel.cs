using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace GuestbookASPNET.ViewModels
{
    public class InscriptionViewModel
    {
        public List<Inscription> Inscriptions { get; set; }
        public Inscription Inscription { get; set; }
    }
}