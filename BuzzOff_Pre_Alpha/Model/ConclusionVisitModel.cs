using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzzOff_Pre_Alpha.Model
{
    internal class ConclusionVisitModel
    {
        public int Id { get; set; }
        public int IdDenunciation { get; set; }
        public byte[] Report  { get; set; }
    }
}
